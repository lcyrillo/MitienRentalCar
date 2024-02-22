using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;

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
    [Route("GetUserTypes")]
    public async Task<IActionResult> GetUserTypes()
    {
        var result = await _userTypeService.GetAll();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetUserTypeById")]
    public async Task<IActionResult> GetUserTypeById([FromQuery] int id)
    {
        var result = await _userTypeService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetUserTypeByDescription")]
    public async Task<IActionResult> GetUserTypeByDescription([FromQuery] string description)
    {
        var result = await _userTypeService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [Route("AddUserType")]
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
    [Route("UpdateUserType")]
    public async Task<IActionResult> UpdateUserTypeAsync([FromBody] UserTypeRequestModel userType)
    {
        if (userType != null)
        {
            var result = await _userTypeService.GetById(userType.Id);

            if (result is null) return NotFound();

            _userTypeService.Update(userType);

            return Ok(userType);
        }

        return BadRequest(userType);
    }

    [HttpDelete]
    [Route("DeleteUserType/{id}")]
    public async Task<IActionResult> DeleteUserType(int id)
    {
        var result = await _userTypeService.GetById(id);

        if (result != null)
        {
            _userTypeService.Delete(id);

            return Ok(result);
        }

        return NotFound(result);
    }
}

