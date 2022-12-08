namespace Mitien.RentalCar.Business.Entities
{
    public class VehicleCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
