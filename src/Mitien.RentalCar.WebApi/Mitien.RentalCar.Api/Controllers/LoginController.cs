using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.Services.Util;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public LoginController(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("register")]
    public IActionResult Register(UserRequestModel userRequestModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(userRequestModel.Password))
            return BadRequest("Password cannot be null");

        PasswordHash.CreatePasswordHash(userRequestModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

        return Ok();
    }

    
}