using Newtonsoft.Json.Linq;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Helpers;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using System.Net.Http.Headers;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.Application.Entities.Location.Services;

public class LocationService(IHttpClientFactory httpClientFactory) : ILocationService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Dadata");

    public async Task<OperationResult<IEnumerable<AddressDto>>> ReverseGeocodeAsync(LocationDto locationDto)
    {
        try
        {
            const string url = "/suggestions/api/4_1/rs/geolocate/address";

            var content = LocationHelperService.CompilingData(locationDto);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "9b5dcf4d97607746e3949d2c8629d05574931124");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonResponse);
                var parsedSuggestions = jsonObject["suggestions"]?.ToObject<List<Suggestion>>();
                
                return OperationResult<IEnumerable<AddressDto>>.SuccessResult(LocationHelperService.ConvertToAddressDtoList(parsedSuggestions ?? new List<Suggestion>()));
            }
            else
                return OperationResult<IEnumerable<AddressDto>>.FailedResult($"{response.StatusCode} {response.ReasonPhrase!}");
        }
        catch (HttpRequestException ex)
        {
            return OperationResult<IEnumerable<AddressDto>>.FailedResult($"HTTP error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            return OperationResult<IEnumerable<AddressDto>>.FailedResult($"An error occurred: {ex.Message}");
        }
    }
}