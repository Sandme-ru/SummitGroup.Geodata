using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.Application.Entities.Location.Interfaces;

/// <summary>
/// Interface ILocationService
/// </summary>
public interface ILocationService
{
    /// <summary>
    /// Reverses the geocode asynchronous.
    /// </summary>
    /// <param name="locationDto">The location dto.</param>
    /// <returns>Task&lt;OperationResult&lt;IEnumerable&lt;AddressDto&gt;&gt;&gt;.</returns>
    Task<OperationResult<IEnumerable<AddressDto>>> ReverseGeocodeAsync(LocationDto locationDto);
}