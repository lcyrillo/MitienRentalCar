using Dapper;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.RequestModels;
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

    public async Task<UserTypeResponseModel> GetById(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var userTypes = await connection.QueryFirstOrDefaultAsync<UserTypeDTO>("select * from USER_TYPE where id = @Id", new { Id = id });

        return userTypes.ToUserTypeResponseModel();
    }

    public async Task<List<UserTypeResponseModel>> GetByDescription(string description)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var userTypes = await connection.QueryAsync<UserTypeDTO>("select * from USER_TYPE where description like @Description ", new { Description = "%" + description + "%" });

        return userTypes.ToListOfUserTypeResponseModel().ToList();
    }

    public async void Add(UserTypeRequestModel userTypeRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("insert into USER_TYPE (description, mnemonic) values (@Description, @Mnemonic)", userTypeRequestModel);
    }

    public async void Update(UserTypeRequestModel userTypeRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("update USER_TYPE set description = @Description, mnemonic = @Mnemonic where id = @Id", 
                                        new { userTypeRequestModel.Description, userTypeRequestModel.Mnemonic, userTypeRequestModel.Id });
    }

    public async void Delete(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("delete from USER_TYPE where id = @Id", new { Id = id });
    }
}

