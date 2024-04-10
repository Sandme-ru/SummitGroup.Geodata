using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using Newtonsoft.Json;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;
using Microsoft.Extensions.Logging;

namespace SummitGroup.Geodata.Application.Entities.Address.Services;

/// <summary>
/// Class AddressService.
/// Implements the <see cref="IAddressService" />
/// </summary>
/// <seealso cref="IAddressService" />
public class AddressService(IHttpClientFactory httpClientFactory, ILogger<AddressService> logger) : IAddressService
{

    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Nominatim");

    /// <summary>
    /// Get geo data as an asynchronous operation.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<LocationDto>> GetGeoDataAsync(AddressDto address)
    {
        try
        {
            var url = $"/search?country={address.Country}&city={address.City} {address.Region}&street={address.Street} {address.House} {address.Apartment}&format=json&limit=1";

            logger.LogInformation($"Sending GET request to {url}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsedLocation = JsonConvert.DeserializeObject<List<Domain.Address>>(json);

                if (parsedLocation != null)
                {
                    if (parsedLocation.Any())
                    {
                        var location = new LocationDto
                        {
                            Latitude = Convert.ToDouble(parsedLocation[0].lat),
                            Longitude = Convert.ToDouble(parsedLocation[0].lon),
                        };

                        logger.LogInformation("Location data successfully retrieved.");
                        return OperationResult<LocationDto>.SuccessResult(location);
                    }

                    logger.LogWarning("[NO CONTENT: 204] Введены некорретные входные параметры для определения геолокации адреса");
                    return OperationResult<LocationDto>.FailedResult("[NO CONTENT: 204] Введены некорретные входные параметры для определения геолокации адреса");
                }
                else
                {
                    logger.LogError("[NO CONTENT: 204] Parsed location is null value");
                    return OperationResult<LocationDto>.FailedResult("[NO CONTENT: 204] Parsed location in null value");
                }
            }
            else
            {
                logger.LogError($"Response failed with status code: {response.StatusCode}");
                return OperationResult<LocationDto>.FailedResult(response.ReasonPhrase!);
            }
        }
        catch (HttpRequestException ex)
        {
            logger.LogError($"HTTP error occurred: {ex.Message}");
            return OperationResult<LocationDto>.FailedResult($"HTTP error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError($"An error occurred: {ex.Message}");
            return OperationResult<LocationDto>.FailedResult($"An error occurred: {ex.Message}");
        }
    }
}