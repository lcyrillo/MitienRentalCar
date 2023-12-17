using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/v1/[controller]")]
public class UserTypeController : Controller
{
    private readonly IUserTypeService _userTypeService;

    public UserTypeController(IUserTypeService userTypeService)
    {
        _userTypeService = userTypeService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetUserTypes()
    {
        var result = await _userTypeService.GetAll();

        if (result is null)
            return BadRequest(new UserTypeResponseModel());

        return Ok(result);
    }

    [HttpGet]
    [Route("GetUserTypeById")]
    public async Task<IActionResult> GetUserTypeById([FromQuery] int id)
    {
        var result = await _userTypeService.GetById(id);

        if (result is null)
            return BadRequest(new UserTypeResponseModel());

        return Ok(result);
    }

    [HttpGet]
    [Route("GetUserTypeByDescription")]
    public async Task<IActionResult> GetUserTypeByDescription([FromQuery] string description)
    {
        var result = await _userTypeService.GetByDescription(description);

        if (result is null)
            return BadRequest(new UserTypeResponseModel());

        return Ok(result);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult AddUserType([FromBody] UserTypeRequestModel userType)
    {
        if (userType != null)
        {
            _userTypeService.Add(userType);

            return StatusCode(StatusCodes.Status201Created, userType);
        }
        
        return BadRequest(userType);
    }

    [HttpPut]
    [Route("[action]")]
    public IActionResult UpdateUserType([FromBody] UserTypeRequestModel userType)
    {
        if (userType != null)
        {
            _userTypeService.Update(userType);

            return Ok(userType);
        }

        return BadRequest(userType);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> DeleteUserType(int id)
    {
        if (id != 0)
        {
            var result = await _userTypeService.Delete(id);

            return Ok(result);
        }

        return BadRequest();
    }
}

