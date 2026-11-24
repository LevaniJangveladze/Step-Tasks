using TemperatureApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ITemperatureConverter, ToFahrenheit>();
builder.Services.AddScoped<ITemperatureConverter, ToKelvin>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TemperatureApi v1");
    });
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();