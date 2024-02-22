using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Interfaces.Services;

public interface IDocumentTypeService
{
    public Task<List<DocumentTypeResponseModel?>> GetAll();
    public Task<DocumentTypeResponseModel?> GetById(int id);
    public Task<List<DocumentTypeResponseModel?>> GetByDescription(string description);
    public void Add(DocumentTypeRequestModel userTypeRequestModel);
    public void Update(DocumentTypeRequestModel userTypeRequestModel);
    public void Delete(int id);
}
