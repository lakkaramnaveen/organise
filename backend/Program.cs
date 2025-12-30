using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddDbContext<AppDbContext>(op=>op.UseSqlite("Data Source=Person.db"));
var app = builder.Build();
    

// middleware pipeline configuration
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
