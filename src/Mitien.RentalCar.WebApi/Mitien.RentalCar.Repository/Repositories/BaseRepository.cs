using Mitien.RentalCar.Business.Entities;
using Mitien.RentalCar.Business.Interfaces.Repositories;

namespace Mitien.RentalCar.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }
}
