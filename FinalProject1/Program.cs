using System.Data.SQLite;
using FinalProject1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (!File.Exists("./FinalProject.sqlite"))
{
    SQLiteConnection.CreateFile("FinalProject.sqlite");
}
    

var connection = builder.Configuration.GetConnectionString("SQLite_CONNECTIONSTRING");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseSqlite(connection ?? throw new InvalidOperationException("Connection string 'DbContext' not found.")));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
