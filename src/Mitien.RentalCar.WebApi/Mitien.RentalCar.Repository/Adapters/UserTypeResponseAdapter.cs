using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.DTOs;

namespace Mitien.RentalCar.Repository.Adapters;

public static class UserTypeResponseAdapter
{
    public static UserTypeResponseModel? ToUserTypeResponseModel(this UserTypeDTO userTypeDTO)
    {
        if (userTypeDTO == null)
            return null;

        return new UserTypeResponseModel()
        {
            Id = userTypeDTO.Id,
            Description = userTypeDTO.Description,
            Mnemonic = userTypeDTO.Mnemonic,
        };
    }

    public static IEnumerable<UserTypeResponseModel?> ToListOfUserTypeResponseModel(this IEnumerable<UserTypeDTO> userTypesDTO)
    {
        if (userTypesDTO != null)
        {
            foreach (var userTypeDTO in userTypesDTO)
                yield return ToUserTypeResponseModel(userTypeDTO);
        }
    }
}

