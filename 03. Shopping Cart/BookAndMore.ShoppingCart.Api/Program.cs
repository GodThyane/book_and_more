using BookAndMore.Commons.Application.Exceptions;
using BookAndMore.Commons.Application.Interfaces;
using BookAndMore.Commons.Persistance.Repositories;
using BookAndMore.ShoppingCart.Application.Repositories;
using BookAndMore.ShoppingCart.Application.Services;
using BookAndMore.ShoppingCart.Domain.Models;
using BookAndMore.ShoppingCart.Infrastructure.Services;
using BookAndMore.ShoppingCart.Persistence;
using BookAndMore.ShoppingCart.Persistence.Repositories;
using BookAndMore.ShoppingCart.Proxy;
using BookAndMore.ShoppingCart.Proxy.Book;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<GlobalExceptionFilter>();
    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddDbContext<ShoppingCartContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingCartConnection")));

builder.Services.Configure<ApiUrl>(options =>
{
    builder.Configuration.GetSection("ApiUrl").Bind(options);
});

builder.Services.AddHttpClient<IBookProxy, BookProxy>();

builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddTransient<IRepository<ShoppingCart, int>, BaseRepository<ShoppingCart, ShoppingCartContext, int>>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
