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
    [Route("GetVehicleCategory")]
    public async Task<IActionResult> GetVehicleCategory()
    {
        var result = await _vehicleCategoryService.GetAll();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetVehicleCategoryById")]
    public async Task<IActionResult> GetVehicleCategoryById([FromQuery] int id)
    {
        var result = await _vehicleCategoryService.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("GetVehicleCategoryByDescription")]
    public async Task<IActionResult> GetVehicleCategoryByDescription([FromQuery] string description)
    {
        var result = await _vehicleCategoryService.GetByDescription(description);

        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [Route("AddVehicleCategory")]
    public IActionResult AddVehicleCategory([FromBody] VehicleCategoryRequestModel vehicleCategory)
    {
        if (vehicleCategory != null)
        {
            _vehicleCategoryService.Add(vehicleCategory);

            return StatusCode(StatusCodes.Status201Created, vehicleCategory);
        }

        return BadRequest(vehicleCategory);
    }

    [HttpPut]
    [Route("UpdateVehicleCategory")]
    public async Task<IActionResult> UpdateVehicleCategory([FromBody] VehicleCategoryRequestModel vehicleCategory)
    {
        if (vehicleCategory != null)
        {
            var result = await _vehicleCategoryService.GetById(vehicleCategory.Id);

            if (result is null) return NotFound();

            _vehicleCategoryService.Update(vehicleCategory);

            return Ok(vehicleCategory);
        }

        return BadRequest(vehicleCategory);
    }

    [HttpDelete]
    [Route("DeleteVehicleCategory/{id}")]
    public async Task<IActionResult> DeleteVehicleCategory(int id)
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

