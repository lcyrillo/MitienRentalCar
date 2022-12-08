namespace Mitien.RentalCar.Business.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Vehicle? Vehicle { get; set; }
        public Location? PickupLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public Location? DropOffLocation { get; set; }

    }
}
