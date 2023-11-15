namespace CliTest.Domain.Entities;

public class Weather 
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public required string Description { get; set; }
}