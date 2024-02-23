using Dapper;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.Adapters;
using Mitien.RentalCar.Repository.DTOs;
using System.Data.SqlClient;

namespace Mitien.RentalCar.Repository.Repositories;

public class VehicleCategoryRepository : IVehicleCategoryRepository
{
    private readonly IConfiguration _config;

    public VehicleCategoryRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<VehicleCategoryResponseModel?>> GetAll()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var vehicleCategories = await connection.QueryAsync<VehicleCategoryDTO>("select * from VEHICLE_CATEGORY");

        return vehicleCategories.ToListOfVehicleCategoryResponseModel().ToList();
    }

    public async Task<VehicleCategoryResponseModel?> GetById(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var vehicleCategories = await connection.QueryFirstOrDefaultAsync<VehicleCategoryDTO>("select * from VEHICLE_CATEGORY where id = @Id", new { Id = id });

        return vehicleCategories.ToVehicleCategoryResponseModel();
    }

    public async Task<List<VehicleCategoryResponseModel?>> GetByDescription(string description)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var vehicleCategories = await connection.QueryAsync<VehicleCategoryDTO>("select * from VEHICLE_CATEGORY where description like @Description ", new { Description = "%" + description + "%" });

        return vehicleCategories.ToListOfVehicleCategoryResponseModel().ToList();
    }

    public async void Add(VehicleCategoryRequestModel vehicleCategoryRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("insert into VEHICLE_CATEGORY (name, initials, description) values (@Name, @Initials, @Description)", 
                                         vehicleCategoryRequestModel);
    }

    public async void Update(int id, VehicleCategoryRequestModel vehicleCategoryRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("update VEHICLE_CATEGORY set name = @Name, initials = @Initials, description = @Description where id = @Id",
                                        new { vehicleCategoryRequestModel.Name, 
                                            vehicleCategoryRequestModel.Initials,
                                            vehicleCategoryRequestModel.Description,
                                            id });
    }

    public async void Delete(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("delete from VEHICLE_CATEGORY where id = @Id", new { Id = id });
    }
}

