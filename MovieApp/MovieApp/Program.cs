using Microsoft.EntityFrameworkCore;
using MovieApp.Configuration;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Abstraction;
using MovieApp.DataAccess.Repositories;
using MovieApp.Domain;
using MovieApp.Services.Implementation;
using MovieApp.Services.Interfaces;
using MovieApp.Utilities;
using System;
using MovieApp.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appConfig = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appConfig);

var appSettings = appConfig.Get<AppSettings>();


builder.Services.RegisterModule(appSettings.ConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
