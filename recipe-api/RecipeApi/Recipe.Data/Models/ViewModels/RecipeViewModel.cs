namespace Recipe.Data.Models;

using System.Collections.Generic;

public class RecipeViewModel {
  public long Id { get; set; }

  public string? Name { get; set; }

  public string? Image { get; set; }

  public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();

  public List<StepViewModel> Steps { get; set; } = new List<StepViewModel>();

  public List<RatingViewModel> Rating { get; set; } = new List<RatingViewModel>();
}
