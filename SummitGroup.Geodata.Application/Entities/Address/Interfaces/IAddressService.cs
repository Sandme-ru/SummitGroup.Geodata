using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.Application.Entities.Address.Interfaces;

/// <summary>
/// Interface IAddressService
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Gets the geo data asynchronous.
    /// </summary>
    /// <param name="addressDto">The address dto.</param>
    /// <returns>Task&lt;Domain.Address&gt;.</returns>
    Task<OperationResult<LocationDto>> GetGeoDataAsync(AddressDto addressDto);
}