namespace Mitien.RentalCar.Repository.DTOs;

public class RentalDTO
{
    public int Id { get; set; }
    public ClientDTO? Client { get; set; }
    public VehicleDTO? Vehicle { get; set; }
    public LocationDTO? PickupLocation { get; set; }
    public LocationDTO? DropoffLocation { get; set; }
    public DateTime? PickupDateTime { get; set; }
    public DateTime? DropOffDateTime { get; set; }
    public double? EstimatedPrice { get; set; }
    public double? FinalPrice { get; set; }
}

