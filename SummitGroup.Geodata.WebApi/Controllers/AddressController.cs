using Microsoft.AspNetCore.Mvc;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using SummitGroup.Geodata.Application.Entities.Location.Dto;
using SummitGroup.Geodata.Application.Utilities.OperationResults;

namespace SummitGroup.Geodata.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    [HttpPost("GetLocationTask")]
    public async Task<OperationResult<LocationDto>> GetLocationTask(AddressDto dto)
    {
        var result = await addressService.GetGeoDataAsync(dto);
        return result;
    }
}