﻿using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Calculator.Shared.Services.BaseAndConfigs;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly DbContext DbContext;

    protected Repository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #region Queries

    public async Task<bool> ExistsAsync(int id)
    {
        return await DbContext.Set<TEntity>().AnyAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().AnyAsync(predicate);
    }

    #endregion

    #region Sync Commands

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().UpdateRange(entities);
    }

    #endregion

    #region Async Commands

    public async Task AddAsync(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(entities);
    }

    #endregion
}