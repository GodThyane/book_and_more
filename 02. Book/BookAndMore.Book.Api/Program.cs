using BookAndMore.Book.Application.Repositories;
using BookAndMore.Book.Application.Services;
using BookAndMore.Book.Domain.Models;
using BookAndMore.Book.Infrastructure.Services;
using BookAndMore.Book.Persistence;
using BookAndMore.Book.Persistence.Repositories;
using BookAndMore.Book.Proxy;
using BookAndMore.Book.Proxy.Author;
using BookAndMore.Commons.Application.Exceptions;
using BookAndMore.Commons.Application.Interfaces;
using BookAndMore.Commons.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<GlobalExceptionFilter>();
    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddDbContext<BookContext>(opts =>
    opts.UseNpgsql(builder.Configuration.GetConnectionString("BookConnection")));

builder.Services.Configure<ApiUrl>(options =>
{
    builder.Configuration.GetSection("ApiUrl").Bind(options);
});

builder.Services.AddHttpClient<IAuthorProxy, AuthorProxy>();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IRepository<Book, int>, BaseRepository<Book, BookContext, int>>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
