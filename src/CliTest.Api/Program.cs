using CliTest.Application;
using CliTest.Infrastructure;
using CliTest.Infrastructure.Persistence;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
builder.Services
    .AddApplication()
    .AddInfrastructure(connectionString);

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

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try 
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            DatabaseInitializer.Initalize(context);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

app.Run();
