namespace Learn.SqliteDataSync.Models;

public class BaseSync
{
  public string Id { get; set; } = Guid.NewGuid().ToString("N");

  public DateTimeOffset? SyncUpdateDttm { get; set; }

  /// <summary>Gets or sets the sync-GUID</summary>
  public string? SyncVersion { get; set; }

  /// <summary></summary>
  public bool SyncIsDeleted { get; set; }
}
