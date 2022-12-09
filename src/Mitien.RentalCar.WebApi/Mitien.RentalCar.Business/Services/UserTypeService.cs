using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Services;

public class UserTypeService : IUserTypeService
{
    private readonly IUserTypeRepository _userTypeRepository;

    public UserTypeService(IUserTypeRepository userTypeRepository)
    {
        _userTypeRepository = userTypeRepository;
    }

    public Task<List<UserTypeResponseModel>> GetAll()
    {
        return _userTypeRepository.GetAll();
    }
}

