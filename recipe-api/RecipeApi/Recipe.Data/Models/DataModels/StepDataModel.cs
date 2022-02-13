namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("steps")]
public class StepDataModel : EntityDataModel
{
    [Column("recipe_id")]
    public long RecipeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Order { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("RecipeId")]
    public virtual RecipeDataModel Recipe { get; set; } = new RecipeDataModel();
}