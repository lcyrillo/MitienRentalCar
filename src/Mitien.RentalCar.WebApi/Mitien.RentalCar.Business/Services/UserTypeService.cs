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

    public Task<List<UserTypeResponseModel>> GetAll()
    {
        return _userTypeRepository.GetAll();
    }

    public Task<UserTypeResponseModel> GetById(int id)
    {
        return _userTypeRepository.GetById(id);
    }

    public Task<List<UserTypeResponseModel>> GetByDescription(string description)
    {
        return _userTypeRepository.GetByDescription(description);
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
        _userTypeRepository.Delete(id);
    }
}

