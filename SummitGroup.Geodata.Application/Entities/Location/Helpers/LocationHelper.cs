using Newtonsoft.Json;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.RequestModel;
using System.Text;

namespace SummitGroup.Geodata.Application.Entities.Location.Helpers;

/// <summary>
/// Class LocationHelperService.
/// </summary>
public static class LocationHelperService
{
    /// <summary>
    /// The random
    /// </summary>
    private static readonly Random Random = new();

    /// <summary>
    /// The radius value
    /// </summary>
    private const int RadiusValue = 1000;

    /// <summary>
    /// The address count
    /// </summary>
    private const int AddressCount = 10;

    /// <summary>
    /// Converts to address dto list.
    /// </summary>
    /// <param name="suggestions">The suggestions.</param>
    /// <returns>IEnumerable&lt;AddressDto&gt;.</returns>
    public static IEnumerable<AddressDto> ConvertToAddressDtoList(List<Suggestion> suggestions)
    {
        if (suggestions.Any())
        {
            return suggestions.Select(suggestion => new AddressDto
            {
                Country = suggestion.Data.Country,
                Region = suggestion.Data.Region,
                City = suggestion.Data.City,
                Street = suggestion.Data.Street,
                House = suggestion.Data.House,
                Apartment = GenerateRandomApartmentNumber()
            });
        }
        else
            return new List<AddressDto>();
    }

    /// <summary>
    /// Generates the random apartment number.
    /// </summary>
    /// <returns>System.String.</returns>
    private static string GenerateRandomApartmentNumber()
    {
        return Random.Next(1, 31).ToString();
    }

    /// <summary>
    /// Compilings the data.
    /// </summary>
    /// <param name="locationDto">The location dto.</param>
    /// <returns>StringContent.</returns>
    public static StringContent CompilingData(LocationDto locationDto)
    {
        var requestData = new LocationRequest
        {
            count = AddressCount,
            lat = locationDto.Latitude,
            lon = locationDto.Longitude,
            radius = RadiusValue
        };

        return new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
    }
}