using Mitien.RentalCar.Business.Entities;
using Mitien.RentalCar.Business.Interfaces.Repositories;

namespace Mitien.RentalCar.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public void Add(T userTypeRequestModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetByDescription(string description)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T userTypeRequestModel)
    {
        throw new NotImplementedException();
    }
}
