using Dapper;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Repository.DTOs;
using System.Data.SqlClient;

namespace Mitien.RentalCar.Repository.Repositories;

public class UserTypeRepository
{
    private readonly IConfiguration _config;

    public UserTypeRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<UserTypeDTO>> GetAll()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var userTypes = await connection.QueryAsync<UserTypeDTO>("select * from USER_TYPE");

        return userTypes.ToList();
    }
    //youtube = CRUD with Dapper in a .NET 6 Web API using SQL Server 
}

