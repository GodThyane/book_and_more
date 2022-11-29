using BookAndMore.Bus.RabbitMQ.Commands;
using BookAndMore.Bus.RabbitMQ.Events;

namespace BookAndMore.Bus.RabbitMQ.RabbitBus;

public interface IRabbitEventBus
{
    Task SendCommand<T>(T command) where T : Command;
    void Publish<T>(T @event) where T : Event;
    void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
}