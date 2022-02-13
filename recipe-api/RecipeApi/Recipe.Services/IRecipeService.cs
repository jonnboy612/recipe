namespace Recipe.Services;

using Recipe.Data.Models;

public interface IRecipeService
{
    Recipe Get(long id);

    List<Recipe> Get(bool includeDetail = false);

    Recipe Create(Recipe recipe);

    Recipe Update(Recipe recipe);

    bool Delete(long id);
}