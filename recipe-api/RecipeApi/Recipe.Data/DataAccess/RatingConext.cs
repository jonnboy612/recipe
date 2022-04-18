namespace Recipe.Data.DataAccess;

using Recipe.Data.Models;

using Microsoft.EntityFrameworkCore;

public class RatingContext : DbContext, IRatingContext
{
    /// <summary>
    /// The database connection string.
    /// </summary>
    private string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// The Rating table.
    /// </summary>
    public virtual DbSet<RatingDataModel>? Recipes { get; set; }

    /// <summary>
    /// The Comment table.
    /// </summary>
    public virtual DbSet<CommentDataModel>? Ingredients { get; set; }

    public RatingContext(DbContextOptions<RatingContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    DbSet<TEntity> IRatingContext.Set<TEntity>()
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