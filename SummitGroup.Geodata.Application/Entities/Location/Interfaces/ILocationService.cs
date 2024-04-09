using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;

namespace SummitGroup.Geodata.Application.Entities.Location.Interfaces;

public interface ILocationService
{
    Task<List<AddressDto>> ReverseGeocodeAsync(LocationDto locationDto);
}