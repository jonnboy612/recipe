namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("comments")]
public class CommentDataModel : EntityDataModel
{
    [Column("rating_id")]
    public long RatingId { get; set; }

    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("RatingId")]
    public virtual RatingDataModel Recipe { get; set; } = new RatingDataModel();
}
