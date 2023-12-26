using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Api.ViewModel;
using Mitien.RentalCar.Business.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public LoginController(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    [HttpPost("register")]
    public IActionResult Register(UserViewModel userViewModel)
    {
        if (userViewModel == null)
            return BadRequest("No data informed");

        if (userViewModel.Password == null)
            return BadRequest("Password cannot be null");

        CreatePasswordHash(userViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //SEPARAR EM UMA SERVICE
        //VALIDAR INFORMAÇÕES
        User user = new User();
        
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Email = userViewModel.Email;
        user.Name = userViewModel.Name;
        user.Nationality = userViewModel.Nationality;
        user.DocumentType = userViewModel.DocumentType;
        user.Cpf = userViewModel.Cpf;
        user.ForeignDocument = userViewModel.ForeignDocument;
        user.PassportNumber = userViewModel.PassportNumber;
        user.Gender = userViewModel.Gender;
        user.PhoneNumber = userViewModel.PhoneNumber;
        user.Birthday = userViewModel.Birthday;

        //GRAVAR USUARIO

        return Ok(user);
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}