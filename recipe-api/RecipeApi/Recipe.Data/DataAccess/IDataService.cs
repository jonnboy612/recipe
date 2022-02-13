namespace Recipe.Data.DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using Recipe.Data.Models;

public interface IDataService
{
    IQueryable<TEntity> Get<TEntity>(bool asNoTracking = false)
        where TEntity : class;

    TEntity? GetById<TId, TEntity>(TId id, bool asNoTracking = false)
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>;

    void Insert<TEntity>(TEntity entity)
        where TEntity : class;

    void Insert<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class;

    void Update<TEntity>(TEntity entityToUpdate)
        where TEntity : class;

    void Update<TEntity>(IEnumerable<TEntity> values)
        where TEntity : class;

    bool Delete<TId, TEntity>(TId id)
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>;

    bool Delete<TEntity>(TEntity entityToDelete)
        where TEntity : class;

    int Save();
}