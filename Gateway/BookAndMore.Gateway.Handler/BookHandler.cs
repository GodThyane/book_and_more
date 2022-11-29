using System.Text.Json;
using BookAndMore.Bus.RabbitMQ.EventQueue;
using BookAndMore.Bus.RabbitMQ.RabbitBus;
using BookAndMore.Gateway.Remote;

namespace BookAndMore.Gateway.Handler;

public class BookHandler : DelegatingHandler
{
    private readonly IRabbitEventBus _rabbitEventBus;

    public BookHandler(IRabbitEventBus rabbitEventBus)
    {
        _rabbitEventBus = rabbitEventBus;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var res = await base.SendAsync(request, cancellationToken);
        if (res.IsSuccessStatusCode)
        {
            var book = await res.Content.ReadAsStringAsync(cancellationToken);
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<RemoteBookDto>(book, opt)!;
            _rabbitEventBus.Publish(new EmailQueue("cuentadedaza1@outlook.com", result.Title, "Book created successfully"));
        }
        
        return res;
    }
}