using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/v1/[controller]")]
public class DocumentTypeController : Controller
{
    private readonly IDocumentTypeService _documentTypeService;

    public DocumentTypeController(IDocumentTypeService documentTypeService)
    {
        _documentTypeService = documentTypeService;
    }

    [HttpGet]
    [Route("GetDocumentTypes")]
    public async Task<IActionResult> GetDocumentTypes()
    {
        var result = await _documentTypeService.GetAll();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetDocumentTypeById")]
    public async Task<IActionResult> GetDocumentTypeById([FromQuery] int id)
    {
        var result = await _documentTypeService.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetDocumentTypeByDescription")]
    public async Task<IActionResult> GetDocumentTypeByDescription([FromQuery] string description)
    {
        var result = await _documentTypeService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [Route("AddDocumentType")]
    public IActionResult AddDocumentType([FromBody] DocumentTypeRequestModel documentType)
    {
        if (documentType != null)
        {
            _documentTypeService.Add(documentType);

            return StatusCode(StatusCodes.Status201Created, documentType);
        }

        return BadRequest(documentType);
    }

    [HttpPut]
    [Route("UpdateDocumentType")]
    public async Task<IActionResult> UpdateDocumentType([FromBody] DocumentTypeRequestModel documentType)
    {
        if (documentType != null)
        {
            var result = await _documentTypeService.GetById(documentType.Id);

            if (result is null) return NotFound();

            _documentTypeService.Update(documentType);

            return Ok(documentType);
        }

        return BadRequest(documentType);
    }

    [HttpDelete]
    [Route("DeleteDocumentType/{id}")]
    public async Task<IActionResult> DeleteDocumentType(int id)
    {
        var result = await _documentTypeService.GetById(id);

        if (result != null)
        {
            _documentTypeService.Delete(id);

            return Ok(result);
        }

        return NotFound(result);
    }
}
