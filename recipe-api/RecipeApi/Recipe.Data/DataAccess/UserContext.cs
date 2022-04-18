namespace Recipe.Data.DataAccess;

using Recipe.Data.Models;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext, IUserContext
{
     /// <summary>
    /// The database connection string.
    /// </summary>
    private string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// The user table.
    /// </summary>
    public virtual DbSet<UserDataModel>? Recipes { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    DbSet<TEntity> IUserContext.Set<TEntity>()
    {
        return base.Set<TEntity>();
    }

    /// <summary>
    /// Saves changes to the database.
    /// </summary>
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}