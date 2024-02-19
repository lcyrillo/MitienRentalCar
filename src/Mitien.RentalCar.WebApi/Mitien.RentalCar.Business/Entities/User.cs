using System.ComponentModel.DataAnnotations;

namespace Mitien.RentalCar.Business.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public DocumentType? DocumentType { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public string ForeignDocument { get; set; } = string.Empty;

        public string PassportNumber { get; set; } = string.Empty;

        public char Gender { get; set;  }

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }
    }
}
