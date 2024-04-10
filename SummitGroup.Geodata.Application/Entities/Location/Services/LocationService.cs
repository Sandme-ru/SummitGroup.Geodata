﻿using Newtonsoft.Json.Linq;
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
public class LocationService(IHttpClientFactory httpClientFactory) : ILocationService
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