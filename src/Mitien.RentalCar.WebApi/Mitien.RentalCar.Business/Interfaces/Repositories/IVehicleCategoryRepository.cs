using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Interfaces.Repositories;

public interface IVehicleCategoryRepository
{
    public Task<List<VehicleCategoryResponseModel?>> GetAll();
    public Task<VehicleCategoryResponseModel?> GetById(int id);
    public Task<List<VehicleCategoryResponseModel?>> GetByDescription(string description);
    public void Add(VehicleCategoryRequestModel vehicleCategoryRequestModel);
    public void Update(int id, VehicleCategoryRequestModel vehicleCategoryRequestModel);
    public void Delete(int id);
}

