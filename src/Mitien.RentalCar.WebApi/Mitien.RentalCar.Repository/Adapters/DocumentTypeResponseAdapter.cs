using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.DTOs;

namespace Mitien.RentalCar.Repository.Adapters;

public static class DocumentTypeResponseAdapter
{
    public static DocumentTypeResponseModel? ToDocumentTypeResponseModel(this DocumentTypeDTO documentTypeDTO)
    {
        if (documentTypeDTO == null)
            return null;

        return new DocumentTypeResponseModel()
        {
            Id = documentTypeDTO.Id,
            Description = documentTypeDTO.Description,
        };
    }

    public static IEnumerable<DocumentTypeResponseModel?> ToListOfDocumentTypeResponseModel(this IEnumerable<DocumentTypeDTO> documentTypesDTO)
    {
        if (documentTypesDTO != null)
        {
            foreach (var documentTypeDTO in documentTypesDTO)
                yield return ToDocumentTypeResponseModel(documentTypeDTO);
        }
    }
}
