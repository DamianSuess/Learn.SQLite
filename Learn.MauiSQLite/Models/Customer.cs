using SQLite;

namespace Test.PrismMaui.Models;

public class Customer
{
  [PrimaryKey, AutoIncrement]
  public int Id { get; set; }

  public string FullName { get; set; } = string.Empty;

  public bool Subscribed { get; set; }
}
