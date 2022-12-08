namespace Mitien.RentalCar.Repository.DTOs;
public class AccessoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public AccessoryTypeDTO? Type { get; set; }
    public MaterialDTO? Material { get; set; }
}

