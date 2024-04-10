using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using SummitGroup.Geodata.Application.Entities.Address.Services;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using SummitGroup.Geodata.Application.Entities.Location.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAddressService, AddressService>();

var dadataUrl = builder.Configuration.GetSection("HttpClientSettings:Dadata").Value; ;
var nominatimUrl = builder.Configuration.GetSection("HttpClientSettings:Nominatim").Value; ;

builder.Services.AddHttpClient("Dadata", client =>
{
    client.BaseAddress = new Uri(dadataUrl!);
});

builder.Services.AddHttpClient("Nominatim", client =>
{
    client.BaseAddress = new Uri(nominatimUrl!);
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
