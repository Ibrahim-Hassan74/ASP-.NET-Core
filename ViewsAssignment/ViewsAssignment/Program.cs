using WeatherServiceLibrary;
using WeatherService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWeatherService, WeatherServiceLibrary.WeatherService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
app.Run();
