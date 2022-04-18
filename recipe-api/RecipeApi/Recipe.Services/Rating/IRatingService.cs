namespace Recipe.Services;

using Recipe.Data.Models;

public interface IRatingService
{
    Rating Get(long id);
    List<Rating> Get(bool includeDetail = false);

    Rating Create(Rating rating);

    Rating Update(Rating rating);
}