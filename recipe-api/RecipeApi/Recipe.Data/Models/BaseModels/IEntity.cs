namespace Recipe.Data.Models;

using System;

/// <summary>
/// A base object with audit information.
/// </summary>
public interface IEntity<TId> : IEntityBase<TId>
{
  /// <summary>
  /// The user id of the entity creator.
  /// </summary>
  long CreatedBy { get; set; }

  /// <summary>
  /// The entity creation timestamp.
  /// </summary>
  /// <remarks>
  /// Defaults in database as "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
  /// </remarks>
  DateTime CreatedDate { get; set; }

  /// <summary>
  /// The user id of the entity updater.
  /// </summary>
  long UpdatedBy { get; set; }

  /// <summary>
  /// The timestamp of the last update.
  /// </summary>
  /// <remarks>
  /// Defaults in database as "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
  /// </remarks>
  DateTime UpdatedDate { get; set; }

  /// <summary>
  /// Whether or not this item is deleted.
  /// </summary>
  /// <remarks>
  /// Defaults to false.
  /// </remarks>
  bool IsDeleted { get; set; }
}
