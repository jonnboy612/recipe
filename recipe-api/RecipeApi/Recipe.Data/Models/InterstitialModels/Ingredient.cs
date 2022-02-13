namespace Recipe.Data.Models;

public class Ingredient : Entity {
  public long RecipeId { get; set; }

  public string? Name { get; set; }

  public string? Quantity { get; set; }
}
