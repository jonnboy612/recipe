namespace Recipe.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("recipes")]
public class RecipeDataModel : EntityDataModel
{
    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public virtual List<IngredientDataModel> Ingredients { get; set; } = new List<IngredientDataModel>();

    /// <summary>
    /// 
    /// </summary>
    public virtual List<StepDataModel> Steps { get; set; } = new List<StepDataModel>();
}