namespace Recipe.Data.Models;

public class Comments : Entity {
  public long RatingId { get; set; }

  public string? Comment { get; set; }
}
