using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.Interfaces.Services;
using Mitien.RentalCar.Business.Services;
using Mitien.RentalCar.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Repositories
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();

// Services
builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
