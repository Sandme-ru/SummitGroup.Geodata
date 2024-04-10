using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using Newtonsoft.Json.Linq;

namespace SummitGroup.Geodata.Application.Entities.Location.Services;

public class LocationService(IHttpClientFactory httpClientFactory) : ILocationService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Dadata");

    public async Task<List<AddressDto>?> ReverseGeocodeAsync(LocationDto locationDto)
    {
        try
        {
            var url = "/suggestions/api/4_1/rs/geolocate/address";

            var requestData = JsonConvert.SerializeObject(locationDto);
            var content = new StringContent(requestData, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "9b5dcf4d97607746e3949d2c8629d05574931124");

            var response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonResponse);
                var parsedSuggestions = jsonObject["suggestions"]?.ToObject<List<Suggestion>>();


                if (parsedSuggestions != null)
                {
                    var addressDtos = LocationToAddressConverter.ConvertToAddressDtoList(parsedSuggestions);
                    return addressDtos;
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
        catch (HttpRequestException ex)
        {
            throw new Exception($"HTTP error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred: {ex.Message}");
        }
    }
}