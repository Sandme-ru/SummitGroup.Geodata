using Newtonsoft.Json;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.RequestModel;
using System.Text;

namespace SummitGroup.Geodata.Application.Entities.Location.Helpers;

public static class LocationHelperService
{
    private static readonly Random Random = new();

    private const int RadiusValue = 500;

    private const int AddressCount = 10;

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

    private static string GenerateRandomApartmentNumber()
    {
        return Random.Next(1, 31).ToString();
    }

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