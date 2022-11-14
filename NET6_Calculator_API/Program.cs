using Microsoft.EntityFrameworkCore;
using NET6_Calculator_API.Data;
using NET6_Calculator_API.Data.Interfaces;
using NET6_Calculator_API.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add context for Logger and grab Sqlite connection string
builder.Services.AddDbContext<LoggerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationContext")));

// Dependcy Injection - Add interface into controllers for for unit testing
builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Add}");

app.Run();
