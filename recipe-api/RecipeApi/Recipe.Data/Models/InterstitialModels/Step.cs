namespace Recipe.Data.Models;

using System.Collections.Generic;

public class Step : Entity {
  public string? Description { get; set; }

  public int Order { get; set; }

  public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
