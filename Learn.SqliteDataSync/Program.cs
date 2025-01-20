namespace Learn.SqliteDataSync;

public class Program : IDisposable
{
  private bool _isDisposed;

  static void Main(string[] args)
  {
    Console.WriteLine("Hello, World!");
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!_isDisposed)
    {
      ////if (disposing)
      ////  dbConnection.Close();

      _isDisposed = true;
    }
  }
  public void Dispose()
  {
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }
}
