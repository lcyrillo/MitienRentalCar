using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.DTOs;

namespace Mitien.RentalCar.Repository.Adapters;

public static class VehicleCategoryResponseAdapter
{
    public static VehicleCategoryResponseModel? ToVehicleCategoryResponseModel(this VehicleCategoryDTO vehicleCategoryDTO)
    {
        if (vehicleCategoryDTO == null) 
            return null;

        return new VehicleCategoryResponseModel()
        {
            Id = vehicleCategoryDTO.Id,
            Name = vehicleCategoryDTO.Name,
            Initials = vehicleCategoryDTO.Initials,
            Description = vehicleCategoryDTO.Description,
        };
    }

    public static IEnumerable<VehicleCategoryResponseModel?> ToListOfVehicleCategoryResponseModel(this IEnumerable<VehicleCategoryDTO> vehicleCategoriesDTO)
    {
        if (vehicleCategoriesDTO != null)
        {
            foreach (var vehicleCategoryDTO in vehicleCategoriesDTO)
                yield return ToVehicleCategoryResponseModel(vehicleCategoryDTO);
        }
    }
}

