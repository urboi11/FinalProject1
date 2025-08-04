using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;

var builder = WebApplication.CreateBuilder(args);


var connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION_STRING");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(options => options.UseSqlServer(connection ?? throw new InvalidOperationException("Connection string for Azure SQL Server not found.")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
