using BookAndMore.Bus.RabbitMQ.Events;

namespace BookAndMore.Bus.RabbitMQ.EventQueue;

public class EmailEventQueue : Event
{
    public string Destination { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public EmailEventQueue(string destination, string title, string body)
    {
        Destination = destination;
        Title = title;
        Body = body;
    }
}