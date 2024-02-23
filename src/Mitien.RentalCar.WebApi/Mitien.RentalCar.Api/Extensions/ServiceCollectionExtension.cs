using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.Services;
using Mitien.RentalCar.Repository.Repositories;

namespace Mitien.RentalCar.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this WebApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Services.AddScoped<IUserTypeService, UserTypeService>();
        applicationBuilder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
        applicationBuilder.Services.AddScoped<IVehicleCategoryService, VehicleCategoryService>();

        return applicationBuilder.Services;
    }

    public static IServiceCollection AddApplicationRepository(this WebApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
        applicationBuilder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
        applicationBuilder.Services.AddScoped<IVehicleCategoryRepository, VehicleCategoryRepository>();

        return applicationBuilder.Services;
    }
}

