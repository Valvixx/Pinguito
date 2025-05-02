using System.Text.Json.Serialization;
using Application.Extensions;
using DataAccess.Extensions;
using Domain.Entities;
using Infrastructure.Extensions;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:Database"];
builder.Services.AddFluentMigrator(connectionString);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDapper();

// DbExtension.Initialize();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
NpgsqlConnection.GlobalTypeMapper.MapEnum<Status>("advert_status");

var app = builder.Build();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.Services.UpdateDatabase();
app.Run();