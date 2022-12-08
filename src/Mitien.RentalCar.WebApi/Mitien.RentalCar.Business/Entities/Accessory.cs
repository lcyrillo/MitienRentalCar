
namespace Mitien.RentalCar.Business.Entities
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
