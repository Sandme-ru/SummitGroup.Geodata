using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.Application.Entities.Location.Interfaces;

public interface ILocationService
{
    Task<OperationResult<IEnumerable<AddressDto>>> ReverseGeocodeAsync(LocationDto locationDto);
}