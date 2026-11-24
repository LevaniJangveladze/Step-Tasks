namespace TemperatureApi.Services;

public interface ITemperatureConverter
{
    decimal Convert(decimal celsius);
}