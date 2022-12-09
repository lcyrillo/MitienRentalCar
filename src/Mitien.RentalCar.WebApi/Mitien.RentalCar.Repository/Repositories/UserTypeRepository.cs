using Dapper;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.Adapters;
using Mitien.RentalCar.Repository.DTOs;
using System.Data.SqlClient;

namespace Mitien.RentalCar.Repository.Repositories;

public class UserTypeRepository : IUserTypeRepository
{
    private readonly IConfiguration _config;

    public UserTypeRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<UserTypeResponseModel>> GetAll()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var userTypes = await connection.QueryAsync<UserTypeDTO>("select * from USER_TYPE");

        return userTypes.ToListOfUserTypeResponseModel().ToList();
    }
}

