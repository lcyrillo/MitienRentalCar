using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Interfaces.Repositories;

public interface IUserTypeRepository
{
    public Task<List<UserTypeResponseModel>> GetAll();
}
