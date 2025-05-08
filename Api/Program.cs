using System.Text.Json.Serialization;
using Application.Extensions;
using Dapper;
using DataAccess.Extensions;
using Domain.Entities;
using Infrastructure.Extensions;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
// NpgsqlConnection.GlobalTypeMapper.MapEnum<Status>("advert_status");
var connectionString = builder.Configuration["ConnectionStrings:Database"];
builder.Services.AddFluentMigrator(connectionString);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDapper();

TestConnection();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


var app = builder.Build();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.Services.UpdateDatabase();
app.Run();



async Task TestConnection()
{
    await using var connection = new NpgsqlConnection(connectionString);
    try
    {
        await connection.OpenAsync();
        var result = await connection.ExecuteScalarAsync("SELECT version();");
        Console.WriteLine("Connected to PostgreSQL: " + result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to connect to PostgreSQL: " + ex.Message);
        Console.WriteLine("Inner exception: " + ex.InnerException?.Message);
    }
}