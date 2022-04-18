namespace Recipe.Data.Models;

public class RatingViewModel
{
  public long Id { get; set; }

  public int rating { get; set; }

  public double ratingAvg { get; set; }
  
  public List<CommentViewModel> Comment { get; set; } = new List<CommentViewModel>();

}
