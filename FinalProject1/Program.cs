using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add DbContext (SQLite)
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseSqlite("Data Source=FinalProject.sqlite"));  // Hardcoded for now

var app = builder.Build();

// ✅ Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();