using System.Text;
using BookAndMore.Bus.RabbitMQ.Events;
using BookAndMore.Bus.RabbitMQ.Implements;
using BookAndMore.Bus.RabbitMQ.RabbitBus;
using BookAndMore.Commons.Application.Config;
using BookAndMore.Gateway.Api.Middleware;
using BookAndMore.Gateway.Handler;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtKey))
    };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var config = new OcelotPipelineConfiguration
{
    AuthorizationMiddleware = async (httpContext, next) =>
    {
        await OcelotAuthorizationMiddleware.Authorize(httpContext, next);
    }
};

await app.UseOcelot(config);


app.Run();
