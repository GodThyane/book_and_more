using BookAndMore.Bus.RabbitMQ.Events;
using BookAndMore.Bus.RabbitMQ.Implements;
using BookAndMore.Bus.RabbitMQ.RabbitBus;
using BookAndMore.Gateway.Handler;
using MediatR;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
{
    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
    var logger = sp.GetRequiredService<ILogger<RabbitEventBus>>();
    return new RabbitEventBus(sp.GetService<IMediator>()!, logger ,scopeFactory);
});

builder.Services.AddMediatR(typeof(Message).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(configuration);

builder.Services.AddOcelot(configuration)
    .AddDelegatingHandler<BookHandler>()
    ;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();


app.Run();
