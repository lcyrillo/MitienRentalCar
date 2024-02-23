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
    public async Task<IActionResult> Get()
    {
        var result = await _userTypeService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userTypeService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("Description")]
    public async Task<IActionResult> GetByDescription([FromQuery] string description)
    {
        var result = await _userTypeService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserTypeRequestModel userType)
    {
        if (userType != null)
        {
            _userTypeService.Add(userType);

            return StatusCode(StatusCodes.Status201Created, userType);
        }
        
        return BadRequest(userType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UserTypeRequestModel userType)
    {
        if (userType != null)
        {
            var result = await _userTypeService.GetById(id);

            if (result is null) return NotFound();

            _userTypeService.Update(id, userType);

            return Ok(userType);
        }

        return BadRequest(userType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
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

