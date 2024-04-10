using Microsoft.AspNetCore.Mvc;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.WebApi.Controllers;

/// <summary>
/// Class LocationController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    /// <summary>
    /// Gets the addresses task.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>OperationResult&lt;IEnumerable&lt;AddressDto&gt;&gt;.</returns>
    [HttpPost("GetAddresses")]
    public async Task<OperationResult<IEnumerable<AddressDto>>> GetAddressesTask(LocationDto dto)
    {
        var result = await locationService.ReverseGeocodeAsync(dto);
        return result;
    }
}