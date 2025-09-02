namespace Lokalizer.Application.Contracts;

public class WeatherForecast
{
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public int TemperatureC { get; set; } = Random.Shared.Next(-20, 55);

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}