
namespace Mitien.RentalCar.Repository.DTOs;

public class VehicleDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public VehicleCategoryDTO? VehicleCategory { get; set; }
    public LocationDTO? VehicleLocation { get; set; }
    public List<AccessoryDTO>? VehicleAccessories { get; set; }
    public double RentalPrice { get; set; }
    public int GasLevel { get; set; }
    public string? LicensePlate { get; set; }
    public string? Chassi { get; set; }
    public string? RegisterNumber { get; set; }
}

