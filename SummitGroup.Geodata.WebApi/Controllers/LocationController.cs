using Microsoft.AspNetCore.Mvc;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Services;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Interfaces;

namespace SummitGroup.Geodata.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpPost("GetAddresses")]
    public async Task<List<AddressDto>?> GetAddressesTask(LocationDto dto)
    {
        var result = await locationService.ReverseGeocodeAsync(dto);
        return result;
    }
}