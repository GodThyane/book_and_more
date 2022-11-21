using BookAndMore.Author.Application.Exceptions;
using BookAndMore.Author.Application.Repositories;
using BookAndMore.Author.Application.Services;
using BookAndMore.Author.Domain.Models;
using BookAndMore.Author.Infrastructure.Services;
using BookAndMore.Author.Persistance;
using BookAndMore.Author.Persistance.Repositories;
using BookAndMore.Commons.Application.Interfaces;
using BookAndMore.Commons.Persistance.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<GlobalExceptionFilter>();
    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AuthorContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AuthorConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IRepository<Author, int>, BaseRepository<Author, AuthorContext, int>>();
builder.Services.AddTransient<IAuthorService, AuthorService>();

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