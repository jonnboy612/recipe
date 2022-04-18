namespace Recipe.Data.Models;

public class Rating : Entity {
  public long RecipeId { get; set; }

  public int rating { get; set; }

  public double ratingAvg { get; set; }

  public List<Comments> Comment { get; set; } = new List<Comments>();

  
}
