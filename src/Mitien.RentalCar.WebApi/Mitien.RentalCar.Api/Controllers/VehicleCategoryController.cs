using Microsoft.AspNetCore.Mvc;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.RequestModels;

namespace Mitien.RentalCar.Api.Controllers;

[Route("api/v1/[controller]")]
public class VehicleCategoryController : Controller
{
    private readonly IVehicleCategoryService _vehicleCategoryService;

    public VehicleCategoryController(IVehicleCategoryService vehicleCategoryService)
    {
        _vehicleCategoryService = vehicleCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _vehicleCategoryService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _vehicleCategoryService.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("Description")]
    public async Task<IActionResult> GetByDescription([FromQuery] string description)
    {
        var result = await _vehicleCategoryService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] VehicleCategoryRequestModel vehicleCategory)
    {
        if (vehicleCategory != null)
        {
            _vehicleCategoryService.Add(vehicleCategory);

            return StatusCode(StatusCodes.Status201Created, vehicleCategory);
        }

        return BadRequest(vehicleCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VehicleCategoryRequestModel vehicleCategory)
    {
        if (vehicleCategory != null)
        {
            var result = await _vehicleCategoryService.GetById(id);

            if (result is null) return NotFound();

            _vehicleCategoryService.Update(id, vehicleCategory);

            return Ok(vehicleCategory);
        }

        return BadRequest(vehicleCategory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _vehicleCategoryService.GetById(id);

        if (result != null)
        {
            _vehicleCategoryService.Delete(id);

            return Ok(result);
        }

        return NotFound(result);
    }
}

