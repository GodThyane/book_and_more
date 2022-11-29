using BookAndMore.Bus.RabbitMQ.Events;

namespace BookAndMore.Bus.RabbitMQ.Commands;

public abstract class Command : Message
{
    public DateTime Timestamp { get; protected set; }

    protected Command()
    {
        Timestamp = DateTime.Now;
    }
}