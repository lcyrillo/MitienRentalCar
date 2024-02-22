﻿namespace Mitien.RentalCar.Business.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task<List<T>> GetAll();
    public Task<T> GetById(int id);
    public Task<List<T>> GetByDescription(string description);
    public void Add(T userTypeRequestModel);
    public void Update(T userTypeRequestModel);
    public void Delete(int id);
}

