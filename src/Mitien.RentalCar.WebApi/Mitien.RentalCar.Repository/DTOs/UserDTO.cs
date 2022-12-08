namespace Mitien.RentalCar.Repository.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public DocumentTypeDTO? DocumentType { get; set; }
    public string? Cpf { get; set; }
    public string? ForeignDocument { get; set; }
    public int? PassportNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Birthday { get; set; }
    public UserType? UserType { get; set; }
}

