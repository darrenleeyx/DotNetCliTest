using CliTest.Domain.Entities;

namespace CliTest.Infrastructure.Persistence;

public class DatabaseInitializer
{
    public static void Initalize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Weathers.Any())
        {
            return;
        }

        var now = DateTime.Now;

        var weathers = new List<Weather>
        {
            new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now.AddHours(-10),
                Description = "Sunny"
            },
            new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now.AddHours(-20),
                Description = "Cloudy"
            }
            ,new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now.AddHours(-30),
                Description = "Rainy"
            }
        };

        context.Weathers.AddRange(weathers);
        context.SaveChanges();
    }
}