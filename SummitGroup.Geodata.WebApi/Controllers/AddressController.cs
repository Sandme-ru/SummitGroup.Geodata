using Microsoft.AspNetCore.Mvc;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.WebApi.Controllers;

/// <summary>
/// Class AddressController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    /// <summary>
    /// Gets the location task based on the provided address information.
    /// </summary>
    /// <param name="dto">The address information.</param>
    /// <returns>An operation result containing the location data.</returns>turns>
    [HttpPost("GetLocationTask")]
    public async Task<OperationResult<LocationDto>> GetLocationTask(AddressDto dto)
    {
        var result = await addressService.GetGeoDataAsync(dto);
        return result;
    }
}