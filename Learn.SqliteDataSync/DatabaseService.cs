namespace Learn.SqliteDataSync;

public class DatabaseService
{
  public async Task<bool> SyncronizeAsync(CancellationToken cancellation = default)
  {
    bool isPushed, isPulled;

    // Actions:
    // 1. Push updates
    // 2. Pull updates

    isPushed = await SyncPushAsync(cancellation);
    if (!isPushed)
    {
    }

    isPulled = await SyncPullAsync(cancellation);

    return isPushed && isPulled;
  }

  private async Task<bool> SyncPullAsync(CancellationToken cancellation)
  {
    await Task.Yield();
    return true;
  }

  private async Task<bool> SyncPushAsync(CancellationToken cancellation)
  {
    await Task.Yield();
    return true;
  }
}
