using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Data.Models;

/// <summary>
/// Defines an entity with an identifier.
/// </summary>
public class EntityBase : IEntityBase<long>
{
  /// <summary>
  /// The id of the entity.
  /// </summary>
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public long Id { get; set; }
}