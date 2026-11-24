namespace TemperatureApi.Services;

public class ToKelvin : ITemperatureConverter
{
    public decimal Convert(decimal celsius)
    {
        return celsius + 273.15m;
    }
}