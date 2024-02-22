using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Services;

public class UserTypeService : IUserTypeService
{
    private readonly IUserTypeRepository _userTypeRepository;

    public UserTypeService(IUserTypeRepository userTypeRepository)
    {
        _userTypeRepository = userTypeRepository;
    }

    public async Task<List<UserTypeResponseModel?>> GetAll()
    {
        return await _userTypeRepository.GetAll();
    }

    public async Task<UserTypeResponseModel?> GetById(int id)
    {
        return await _userTypeRepository.GetById(id);
    }

    public async Task<List<UserTypeResponseModel?>> GetByDescription(string description)
    {
        return await _userTypeRepository.GetByDescription(description);
    }

    public void Add(UserTypeRequestModel userTypeRequestModel)
    {
        _userTypeRepository.Add(userTypeRequestModel);
    }

    public void Update(UserTypeRequestModel userTypeRequestModel)
    {
        _userTypeRepository.Update(userTypeRequestModel);
    }

    public void Delete(int id)
    {
        var userType = _userTypeRepository.GetById(id);

        if (userType != null)
            _userTypeRepository.Delete(id);
    }
}

