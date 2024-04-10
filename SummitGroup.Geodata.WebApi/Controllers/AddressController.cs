using Microsoft.AspNetCore.Mvc;
using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Address.Interfaces;
using SummitGroup.Geodata.Application.Entities.Location.Dto;

namespace SummitGroup.Geodata.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    [HttpPost("GetLocationTask")]
    public async Task<LocationDto> GetLocationTask(AddressDto dto)
    {
        var result = await addressService.GetGeoDataAsync(dto);
        return result;
    }
}

//{
//"region": "Татарстан",
//"city": "Казань",
//"street": "Ямашева",
//"house": "92",
//"apartment": "47"
//}