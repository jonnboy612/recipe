namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("ingredients")]
public class IngredientDataModel : EntityDataModel
{
    [Column("recipe_id")]
    public long RecipeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Quantity { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("RecipeId")]
    public virtual RecipeDataModel Recipe { get; set; } = new RecipeDataModel();
}