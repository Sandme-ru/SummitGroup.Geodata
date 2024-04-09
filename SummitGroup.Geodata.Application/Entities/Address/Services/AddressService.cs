using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using Newtonsoft.Json;

namespace SummitGroup.Geodata.Application.Entities.Address.Services;

public class AddressService(HttpClient httpClient) : IAddressService
{
    public async Task<Location.Dto.LocationDto> GetGeoDataAsync(AddressDto address)
    {
        try
        {
            var url = $"https://nominatim.openstreetmap.org/search?country={address.Region}&city={address.City}&street={address.Street}&format=json&limit=2";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsedLocation = JsonConvert.DeserializeObject<Domain.Address>(json);
                if (parsedLocation != null)
                {
                    var location = new Location.Dto.LocationDto
                    {
                        Latitude = Convert.ToDouble(parsedLocation.lat),
                        Longitude = Convert.ToDouble(parsedLocation.lon),
                    };
                    return location;
                }
                    
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}