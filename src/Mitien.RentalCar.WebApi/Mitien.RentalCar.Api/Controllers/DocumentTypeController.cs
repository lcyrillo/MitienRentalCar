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
    public async Task<IActionResult> Get()
    {
        var result = await _documentTypeService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _documentTypeService.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("Description")]
    public async Task<IActionResult> GetByDescription([FromQuery] string description)
    {
        var result = await _documentTypeService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DocumentTypeRequestModel documentType)
    {
        if (documentType != null)
        {
            _documentTypeService.Add(documentType);

            return StatusCode(StatusCodes.Status201Created, documentType);
        }

        return BadRequest(documentType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] DocumentTypeRequestModel documentType)
    {
        if (documentType != null)
        {
            var result = await _documentTypeService.GetById(id);

            if (result is null) return NotFound();

            _documentTypeService.Update(id, documentType);

            return Ok(documentType);
        }

        return BadRequest(documentType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
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
