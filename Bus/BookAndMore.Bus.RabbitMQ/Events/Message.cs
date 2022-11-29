using MediatR;

namespace BookAndMore.Bus.RabbitMQ.Events;

public class Message : IRequest<bool>
{
    public string MessageType { get; protected set; }
    
    protected Message()
    {
        MessageType = GetType().Name;
    }
}