using BookAndMore.Bus.RabbitMQ.Events;

namespace BookAndMore.Bus.RabbitMQ.RabbitBus;

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
{
    Task Handle(TEvent @event);
}

public interface IEventHandler
{
    
}