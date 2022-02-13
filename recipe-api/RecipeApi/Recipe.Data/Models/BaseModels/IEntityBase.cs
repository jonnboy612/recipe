using System.ComponentModel.DataAnnotations;

namespace Recipe.Data.Models;

/// <summary>
/// A base entity object model with an id.
/// </summary>
public interface IEntityBase<TId>
{
  /// <summary>
  /// The entity id.
  /// </summary>
  [Key]
  TId Id { get; }
}
