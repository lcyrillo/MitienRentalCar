
namespace Mitien.RentalCar.Business.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public VehicleCategory? VehicleCategory { get; set; }
        public Location? Location { get; set; }
        public List<Accessory>? Accessory { get; set; }
    }
}
