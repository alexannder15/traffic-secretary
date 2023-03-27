using Application.Interfaces;
using Domain.Models.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntityBase
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _entity;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
        _entity = dbContext.Set<T>();
    }

    public IQueryable<T> Query() => _entity;

    public async Task<List<T>> GetAllAsync() =>
        await _entity.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) =>
        await _entity.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T> AddAsync(T entity)
    {
        await _entity.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _entity.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _entity.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}