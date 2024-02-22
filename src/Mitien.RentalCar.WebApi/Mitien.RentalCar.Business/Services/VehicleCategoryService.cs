using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Services;

public class VehicleCategoryService : IVehicleCategoryService
{
    private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

    public VehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository)
    {
        _vehicleCategoryRepository = vehicleCategoryRepository;
    }

    public async Task<List<VehicleCategoryResponseModel?>> GetAll()
    {
        return await _vehicleCategoryRepository.GetAll();
    }

    public async Task<VehicleCategoryResponseModel?> GetById(int id)
    {
        return await _vehicleCategoryRepository.GetById(id);
    }

    public async Task<List<VehicleCategoryResponseModel?>> GetByDescription(string description)
    {
        return await _vehicleCategoryRepository.GetByDescription(description);
    }

    public void Add(VehicleCategoryRequestModel vehicleCategoryRequestModel)
    {
        _vehicleCategoryRepository.Add(vehicleCategoryRequestModel);
    }

    public void Update(VehicleCategoryRequestModel vehicleCategoryRequestModel)
    {
        _vehicleCategoryRepository.Update(vehicleCategoryRequestModel);
    }

    public void Delete(int id)
    {
        _vehicleCategoryRepository.Delete(id);
    }
}

