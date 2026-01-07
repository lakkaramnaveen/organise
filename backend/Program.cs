using backend.Models;
using Microsoft.EntityFrameworkCore;


var AllowedOrigins = "_allowedOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowedOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddDbContext<AppDbContext>(op=>op.UseSqlite("Data Source=Person.db"));
var app = builder.Build();
    

// middleware pipeline configuration
app.UseRouting();
app.UseAuthorization();
app.UseCors(AllowedOrigins);
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
