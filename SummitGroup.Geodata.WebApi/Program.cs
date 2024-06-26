using NLog.Web;
using NLog;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using SummitGroup.Geodata.Application.Entities.Address.Services;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using SummitGroup.Geodata.Application.Entities.Location.Services;
using System.Net.Http.Headers;
using SummitGroup.Geodata.WebApi.Utilities;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var builder = WebApplication.CreateBuilder(args);

#region Logger

builder.Host.ConfigureLogging(logging =>
{
    _ = logging.ClearProviders();
    _ = logging.SetMinimumLevel(LogLevel.Information);
}).UseNLog();

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("INIT MAIN");

#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
#if RELEASE
    c.DocumentFilter<SubdomainRouteAttribute>();
#endif

    c.SwaggerDoc("v1", new() { Title = "SummitGroup.Geodata.TestTask - Shvyrkalov Matvey", Version = "v1" });

});
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAddressService, AddressService>();

var dadataUrl = builder.Configuration.GetSection("HttpClientSettings:Dadata").Value; ;
var nominatimUrl = builder.Configuration.GetSection("HttpClientSettings:Nominatim").Value; ;

builder.Services.AddHttpClient("Dadata", client =>
{
    client.BaseAddress = new Uri(dadataUrl!);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", builder.Configuration.GetSection("DataSettings:DadataToken").Value);
});


builder.Services.AddHttpClient("Nominatim", client =>
{
    client.BaseAddress = new Uri(nominatimUrl!);
    client.DefaultRequestHeaders.UserAgent.ParseAdd(builder.Configuration.GetSection("DataSettings:UserAgent").Value);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
