using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.SqliteDataSync.Models;

public class StockItem : BaseSync
{
  public string Name { get; set; } = string.Empty;

  public bool InStock { get; set; } = false;
}
