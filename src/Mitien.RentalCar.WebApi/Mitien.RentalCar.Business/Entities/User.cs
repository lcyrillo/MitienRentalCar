namespace Mitien.RentalCar.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public HashCode PasswordHash { get; set; }
        public HashCode PasswordSalt { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public DocumentType? DocumentType { get; set; }
        public string? Cpf { get; set; }
        public string? ForeignDocument { get; set; }
        public string? PassportNumber { get; set; }
        public char Gender { get; set;  }
        public string? PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
