using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.Interfaces.Services;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/[controller]")]
public class UserTypeController : Controller
{
    private readonly IUserTypeService _userTypeService;

    public UserTypeController(IUserTypeService userTypeService)
    {
        _userTypeService = userTypeService;
    }

    [HttpGet]
    [Route("v1/GetUserTypes")]
    public async Task<IActionResult> GetUserTypes()
    {
        var userTypes = await _userTypeService.GetAll();

        return Ok(userTypes);
    }
}

