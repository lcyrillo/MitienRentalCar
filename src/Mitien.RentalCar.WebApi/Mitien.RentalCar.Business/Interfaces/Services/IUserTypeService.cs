using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Interfaces.Services;

public interface IUserTypeService
{
    public Task<List<UserTypeResponseModel>> GetAll();
}

