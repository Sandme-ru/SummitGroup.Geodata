using Newtonsoft.Json.Linq;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using System.Net.Http;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using Newtonsoft.Json;

namespace SummitGroup.Geodata.Application.Entities.Location.Services;

public class LocationService(HttpClient httpClient) : ILocationService
{

    public async Task<List<AddressDto>> ReverseGeocodeAsync(LocationDto locationDto)
    {
        try
        {
            var url = $"https://dadata.ru/api/?lat={locationDto.Latitude}&lon={locationDto.Longitude}";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsedLocation = JsonConvert.DeserializeObject<Domain.Location>(json);

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}