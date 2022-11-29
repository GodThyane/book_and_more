using BookAndMore.Bus.RabbitMQ.Events;

namespace BookAndMore.Bus.RabbitMQ.EventQueue;

public class EmailQueue : Event
{
    public string Destination { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public EmailQueue(string destination, string title, string body)
    {
        Destination = destination;
        Title = title;
        Body = body;
    }
}