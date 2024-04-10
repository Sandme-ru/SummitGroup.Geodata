using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using Newtonsoft.Json;

namespace SummitGroup.Geodata.Application.Entities.Address.Services;

public class AddressService(IHttpClientFactory httpClientFactory) : IAddressService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Nominatim");

    public async Task<Location.Dto.LocationDto> GetGeoDataAsync(AddressDto address)
    {
        try
        {
            var url = $"/search?country={address.Country}&city={address.City} {address.Region}&street={address.Street} {address.House} {address.Apartment}&format=json&limit=1";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsedLocation = JsonConvert.DeserializeObject <List<Domain.Address >>(json);
                if (parsedLocation != null)
                {
                    var location = new Location.Dto.LocationDto
                    {
                        lat = Convert.ToDouble(parsedLocation[0].lat),
                        lon = Convert.ToDouble(parsedLocation[0].lon),
                    };
                    return location;
                }
                else
                {
                    return null;
                }
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