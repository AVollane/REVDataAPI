using Microsoft.EntityFrameworkCore;
using RXVBackDL.Repository.DbContexts;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using RXVBackDL.Repository;
using RXVBackDL.Repository.Repositories;
using RXVBackDL.Models.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<NeuronetInformation>, NeuronetInformationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Использование Swagger для тестирования API. Закоментирована, т.к. Swagger мы не используем
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
