using System.Text;
using BookAndMore.Bus.RabbitMQ.Commands;
using BookAndMore.Bus.RabbitMQ.Events;
using BookAndMore.Bus.RabbitMQ.RabbitBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BookAndMore.Bus.RabbitMQ.Implements;

public class RabbitEventBus : IRabbitEventBus
{
    private readonly IMediator _mediator;
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly List<Type> _eventTypes;
    private readonly ILogger<RabbitEventBus> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RabbitEventBus(IMediator mediator, ILogger<RabbitEventBus> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _mediator = mediator;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _handlers = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
    }

    public Task SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672 };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        var eventName = @event.GetType().Name;
        channel.QueueDeclare(eventName, false, false, false, null);
        
        var message = JsonConvert.SerializeObject(@event);
        _logger.LogInformation($"Publishing event: {eventName} - {message}");
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish("", eventName, null, body);
    }

    public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T)))
        {
            _eventTypes.Add(typeof(T));
        }

        if (!_handlers.ContainsKey(eventName))
        {
            _handlers.Add(eventName, new List<Type>());
        }

        if (_handlers[eventName].Any(s => s == handlerType))
        {
            throw new ArgumentException($"Handler Type {handlerType.Name} already is registered for '{eventName}'",
                nameof(handlerType));
        }

        _handlers[eventName].Add(handlerType);

        var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672, DispatchConsumersAsync = true };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(eventName, false, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Delegate;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.ToArray());

        try
        {
            if (_handlers.ContainsKey(eventName))
            {

                using var scope = _serviceScopeFactory.CreateScope();
                
                var subs = _handlers[eventName];
                foreach (var sub in subs)
                {
                    var handler = scope.ServiceProvider.GetService(sub);
                    if (handler == null) continue;

                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var eventDs = JsonConvert.DeserializeObject(message, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle")?.Invoke(handler, new[] { eventDs })!;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}