namespace Recipe.Data.DataAccess;

using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models;

public class DataService : IDataService
{
    private readonly IRecipeContext _context;

    public DataService(IRecipeContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual IQueryable<TEntity> Get<TEntity>(bool asNoTracking = false)
        where TEntity : class
    {
        var context = _context.Set<TEntity>();
        if (asNoTracking)
        {
            return context.AsNoTracking();
        }

        return context;
    }

    public virtual TEntity? GetById<TId, TEntity>(TId id, bool asNoTracking = false)
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        IQueryable<TEntity> entities = Get<TEntity>();

        if (asNoTracking)
        {
            return entities.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        return entities.FirstOrDefault(x => x.Id.Equals(id));
    }

    public virtual void Insert<TEntity>(TEntity entity)
        where TEntity : class
    {
      _context.Set<TEntity>().Add(entity);
    }

    public virtual void Insert<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class
    {
        _context.Set<TEntity>().AddRange(entities.ToList());
    }

    public virtual void Update<TEntity>(TEntity entityToUpdate)
        where TEntity : class
    {
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public void Update<TEntity>(IEnumerable<TEntity> values)
        where TEntity : class
    {
        // create a new collection with ToList() in case we are enumerating the Entity Framework's collection itself
        foreach (TEntity value in values.ToList())
        {
            _context.Entry(value).State = EntityState.Modified;
        }
    }

    public virtual bool Delete<TId, TEntity>(TId id)
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        TEntity? entityToDelete = GetById<TId, TEntity>(id);

        if (entityToDelete == null) {
            return false;
        }

        Delete(entityToDelete);
        return true;
    }

    public virtual bool Delete<TEntity>(TEntity entityToDelete)
        where TEntity : class
    {
        _context.Set<TEntity>().Remove(entityToDelete);
        return true;
    }

    public virtual int Save()
    {
        return _context.SaveChanges();
    }
}