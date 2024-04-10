using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using Newtonsoft.Json;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;
using SummitGroup.Geodata.Application.Entities.Location.Domain;

namespace SummitGroup.Geodata.Application.Entities.Address.Services;

public class AddressService(IHttpClientFactory httpClientFactory) : IAddressService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Nominatim");

    public async Task<OperationResult<LocationDto>> GetGeoDataAsync(AddressDto address)
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
                var parsedLocation = JsonConvert.DeserializeObject <List<Domain.Address>>(json);

                if (parsedLocation != null)
                {
                    if(parsedLocation.Any())
                    {
                        var location = new LocationDto
                        {
                            Latitude = Convert.ToDouble(parsedLocation[0].lat),
                            Longitude = Convert.ToDouble(parsedLocation[0].lon),
                        };

                        return OperationResult<LocationDto>.SuccessResult(location);
                    }

                    return OperationResult<LocationDto>.FailedResult("[NO CONTENT: 204] Введены некорретные входные параметры для определения геолокации адреса");
                }
                else
                    return OperationResult<LocationDto>.FailedResult("[NO CONTENT: 204] Parsed location in null value");
            }
            else
                return OperationResult<LocationDto>.FailedResult(response.ReasonPhrase!);
        }
        catch (HttpRequestException ex)
        {
            return OperationResult<LocationDto>.FailedResult($"HTTP error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            return OperationResult<LocationDto>.FailedResult($"An error occurred: {ex.Message}");
        }
    }
}