namespace Recipe.Data.DataAccess;

using Recipe.Data.Models;

using Microsoft.EntityFrameworkCore;

public class RecipeContext : DbContext, IRecipeContext
{
    /// <summary>
    /// The database connection string.
    /// </summary>
    private string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// The recipes table.
    /// </summary>
    public virtual DbSet<RecipeDataModel>? Recipes { get; set; }

    /// <summary>
    /// The ingredients table.
    /// </summary>
    public virtual DbSet<IngredientDataModel>? Ingredients { get; set; }

    /// <summary>
    /// The steps table.
    /// </summary>
    public virtual DbSet<StepDataModel>? Steps { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    DbSet<TEntity> IRecipeContext.Set<TEntity>()
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