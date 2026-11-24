namespace TemperatureApi.Services;

public class ToFahrenheit : ITemperatureConverter
{
    public decimal Convert(decimal celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}