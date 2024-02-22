    using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;
using Mitien.RentalCar.Business.ResponseModels;

namespace Mitien.RentalCar.Business.Services;

public class DocumentTypeService : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    public Task<List<DocumentTypeResponseModel>> GetAll()
    {
        return _documentTypeRepository.GetAll();
    }

    public Task<DocumentTypeResponseModel> GetById(int id)
    {
        return _documentTypeRepository.GetById(id);
    }

    public Task<List<DocumentTypeResponseModel>> GetByDescription(string description)
    {
        return _documentTypeRepository.GetByDescription(description);
    }

    public void Add(DocumentTypeRequestModel userTypeRequestModel)
    {
        _documentTypeRepository.Add(userTypeRequestModel);
    }

    public void Update(DocumentTypeRequestModel userTypeRequestModel)
    {
        _documentTypeRepository.Update(userTypeRequestModel);
    }

    public void Delete(int id)
    {
        _documentTypeRepository.Delete(id);
    }

}
