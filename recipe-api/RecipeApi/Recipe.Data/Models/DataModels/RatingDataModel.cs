namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("rating")]
public class RatingDataModel : EntityDataModel
{
    [Column("recipe_id")]
    public long RecipeId { get; set; }

    public int rating { get; set; }

    public double ratingAvg { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("RecipeId")]
    public virtual RecipeDataModel Recipe { get; set; } = new RecipeDataModel();

    public List<CommentDataModel> Comment { get; set; } = new List<CommentDataModel>();

}