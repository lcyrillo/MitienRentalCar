
namespace Mitien.RentalCar.Business.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task<List<T>> GetAll();
}

