using Dapper;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.Adapters;
using Mitien.RentalCar.Repository.DTOs;
using System.Data.SqlClient;

namespace Mitien.RentalCar.Repository.Repositories;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly IConfiguration _config;

    public DocumentTypeRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<DocumentTypeResponseModel>> GetAll()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var documentTypes = await connection.QueryAsync<DocumentTypeDTO>("select * from DOCUMENT_TYPE");

        return documentTypes.ToListOfDocumentTypeResponseModel().ToList();
    }

    public async Task<DocumentTypeResponseModel> GetById(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var documentTypes = await connection.QueryFirstOrDefaultAsync<DocumentTypeDTO>("select * from DOCUMENT_TYPE where id = @Id", new { Id = id });

        return documentTypes.ToDocumentTypeResponseModel();
    }

    public async Task<List<DocumentTypeResponseModel>> GetByDescription(string description)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        var documentTypes = await connection.QueryAsync<DocumentTypeDTO>("select * from DOCUMENT_TYPE where description like @Description ", new { Description = "%" + description + "%" });

        return documentTypes.ToListOfDocumentTypeResponseModel().ToList();
    }

    public async void Add(DocumentTypeRequestModel documentTypeRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("insert into DOCUMENT_TYPE (description) values (@Description)", documentTypeRequestModel);
    }

    public async void Update(DocumentTypeRequestModel documentTypeRequestModel)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("update DOCUMENT_TYPE set description = @Description where id = @Id",
                                        new { documentTypeRequestModel.Description, documentTypeRequestModel.Id });
    }

    public async void Delete(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("SqlServer"));
        await connection.ExecuteAsync("delete from DOCUMENT_TYPE where id = @Id", new { Id = id });
    }
}
