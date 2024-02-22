using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Interfaces.Repositories;

public interface IUserTypeRepository
{
    public Task<List<UserTypeResponseModel?>> GetAll();
    public Task<UserTypeResponseModel?> GetById(int id);
    public Task<List<UserTypeResponseModel?>> GetByDescription(string description);
    public void Add(UserTypeRequestModel userTypeRequestModel);
    public void Update(UserTypeRequestModel userTypeRequestModel);
    public void Delete(int id);
}