using Mitien.RentalCar.Business.Entities;

namespace Mitien.RentalCar.Business.RequestModels;

public class UserRequestModel
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
     
    public string Nationality { get; set; } = string.Empty;

    public DocumentType? DocumentType { get; set; }

    public string Cpf { get; set; } = string.Empty;

    public string ForeignDocument { get; set; } = string.Empty;

    public string PassportNumber { get; set; } = string.Empty;

    public char Gender { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime Birthday { get; set; }
}