namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Defines an entity with an identifier.
/// Does not have a deleted flag.
/// </summary>
public class EntityDataModel : EntityBase, IEntity<long>
{
  /// <summary>
  /// The user id of the entity creator.
  /// </summary>
  /// <remarks>
  /// Defaults to 1.
  /// </remarks>
  [Column("created_by")]
  public long CreatedBy { get; set; }

  /// <summary>
  /// The entity creation timestamp.
  /// </summary>
  /// <remarks>
  /// Defaults in database as "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
  /// </remarks>
  [Column("created_date")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime CreatedDate { get; set; }

  /// <summary>
  /// The user id of the entity updater.
  /// </summary>
  /// <remarks>
  /// Defaults to 1.
  /// </remarks>
  [Column("updated_by")]
  public long UpdatedBy { get; set; }

  /// <summary>
  /// The timestamp of the last update.
  /// </summary>
  /// <remarks>
  /// Defaults in database as "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
  /// </remarks>
  [Column("updated_date")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedDate { get; set; }

  /// <summary>
  /// Whether or not this item is deleted.
  /// </summary>
  /// <remarks>
  /// Defaults to false.
  /// </remarks>
  [Column("is_deleted")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public bool IsDeleted { get; set; }
}