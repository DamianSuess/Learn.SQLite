namespace Test.PrismMaui;

public static class Constants
{
  /// <summary>DB File Name.</summary>
  public const string DatabaseFile = "SampleSqlite.db3";

  /// <summary>DB Connection flags.</summary>
  public const SQLite.SQLiteOpenFlags Flags =
    SQLite.SQLiteOpenFlags.ReadWrite |  // Open DB in read/write mode
    SQLite.SQLiteOpenFlags.Create |     // Create DB if not existing
    SQLite.SQLiteOpenFlags.SharedCache; // Allows multi-threaded access

  /// <summary>Path to Database.</summary>
  public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFile);
  public static string DatabasePath2 => Path.Combine(FileSystem.AppDataDirectory, DatabaseFile);
}
