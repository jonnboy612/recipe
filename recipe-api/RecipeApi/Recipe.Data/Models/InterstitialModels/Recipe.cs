namespace Recipe.Data.Models;

using System.Collections.Generic;

public class Recipe : Entity {
  public string? Name { get; set; }

  public string? Image { get; set; }

  public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
  public List<Step> Steps { get; set; } = new List<Step>();
}
