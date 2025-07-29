using System.Data.SQLite;
using FinalProject1.Models;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;

var builder = WebApplication.CreateBuilder(args);

// Create DB file if it doesn't exist
if (!File.Exists("./FinalProject.sqlite"))
{
    SQLiteConnection.CreateFile("FinalProject.sqlite");
}

// ✅ Connection string from appsettings.json
var connection = builder.Configuration.GetConnectionString("SQLite_CONNECTIONSTRING");

// ✅ Register services
builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseSqlite(connection ?? throw new InvalidOperationException("Connection string 'SQLite_CONNECTIONSTRING' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();