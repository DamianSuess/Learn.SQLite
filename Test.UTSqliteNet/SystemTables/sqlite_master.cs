/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-9-13
 * Author:  Damian Suess
 * File:    sqlite_master.cs
 * Description:
 *
 * Reference:
 *  https://www.techonthenet.com/sqlite/sys_tables/index.php
 */

namespace Test.SQLiteX.SystemTables
{
  public class sqlite_master
  {
    public string type { get; set; }

    public string name { get; set; }

    public string tbl_name { get; set; }

    public string rootpage { get; set; }

    public string sql { get; set; }
  }
}
