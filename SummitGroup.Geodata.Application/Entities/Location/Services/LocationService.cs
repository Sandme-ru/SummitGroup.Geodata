using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Helpers;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.Application.Entities.Location.Services;

/// <summary>
/// Class LocationService.
/// Implements the <see cref="ILocationService" />
/// </summary>
/// <seealso cref="ILocationService" />
public class LocationService(IHttpClientFactory httpClientFactory, ILogger<LocationService> logger) : ILocationService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Dadata");

    /// <summary>
    /// Reverse geocode as an asynchronous operation.
    /// </summary>
    /// <param name="locationDto">The location dto.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<IEnumerable<AddressDto>>> ReverseGeocodeAsync(LocationDto locationDto)
    {
        try
        {
            const string url = "/suggestions/api/4_1/rs/geolocate/address";

            var content = LocationHelperService.CompilingData(locationDto);

            logger.LogInformation($"Sending POST request to {url}");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonResponse);
                var parsedSuggestions = jsonObject["suggestions"]?.ToObject<List<Suggestion>>();

                logger.LogInformation("Location data successfully retrieved.");
                return OperationResult<IEnumerable<AddressDto>>.SuccessResult(LocationHelperService.ConvertToAddressDtoList(parsedSuggestions ?? new List<Suggestion>()));
            }
            else
            {
                logger.LogError($"Request failed with status code: {response.StatusCode}");
                return OperationResult<IEnumerable<AddressDto>>.FailedResult($"{response.StatusCode} {response.ReasonPhrase!}");
            }
        }
        catch (HttpRequestException ex)
        {
            logger.LogError($"HTTP error occurred: {ex.Message}");
            return OperationResult<IEnumerable<AddressDto>>.FailedResult($"HTTP error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError($"An error occurred: {ex.Message}");
            return OperationResult<IEnumerable<AddressDto>>.FailedResult($"An error occurred: {ex.Message}");
        }
    }
}