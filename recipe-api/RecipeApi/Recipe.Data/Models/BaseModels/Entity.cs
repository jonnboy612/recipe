namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Entity
{
    public long Id { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}