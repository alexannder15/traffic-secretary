using Domain.Models.Common;

namespace Application.Interfaces;

public interface IRepository<T> where T : IEntityBase
{
    IQueryable<T> Query();
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}