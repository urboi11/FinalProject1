using System.Data.SQLite;
using FinalProject1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinalProject1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProject1Context") ?? throw new InvalidOperationException("Connection string 'FinalProject1Context' not found.")));

// Add services to the container.

if (!File.Exists("./FinalProject.sqlite"))
{
    SQLiteConnection.CreateFile("FinalProject.sqlite");
}
    

var connection = builder.Configuration.GetConnectionString("SQLite_CONNECTIONSTRING");

builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(opt => opt.UseSqlite(connection));
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
