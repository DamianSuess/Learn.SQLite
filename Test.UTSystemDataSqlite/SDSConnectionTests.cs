using System;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UTSystemDataSqlite
{
  [TestClass]
  public class SDSConnectionTests
  {
    [TestMethod]
    public void InMemory_RawCreate_AllTables_Test()
    {
      //// var db = new SQLiteConnection(":memory:", true);
      string connString = "Data Source=:memory:;New=True;";

      SQLiteConnection conn = new SQLiteConnection(connString);
      conn.Open();

      SQLiteCommand cmd = new SQLiteCommand(conn);
      cmd.CommandText = @"
        CREATE TABLE TestTable1 (Id INT, ParamValue VARCHAR(32));
        CREATE TABLE TestTable2 (Id INT, ParamValue VARCHAR(32));

        INSERT INTO TestTable1 (Id, ParamValue) VALUES (1, 'one');
        INSERT INTO TestTable1 (Id, ParamValue) VALUES (2, 'two');

        INSERT INTO TestTable2 (Id, ParamValue) VALUES (1, 'one');
        INSERT INTO TestTable2 (Id, ParamValue) VALUES (2, 'two');";

      cmd.ExecuteNonQuery();

      Int32 cnt = 0;
      cmd.CommandText = "SELECT COUNT(*) FROM TestTable1;";
      var ret = cmd.ExecuteScalar();
      Int32.TryParse(ret.ToString(), out cnt);
      Assert.AreEqual(2, cnt, "Table-1 Invalid row count");

      cmd.CommandText = "SELECT COUNT(*) FROM TestTable2;";
      ret = cmd.ExecuteScalar();
      Int32.TryParse(ret.ToString(), out cnt);
      Assert.AreEqual(2, cnt, "Table-2 Invalid row count");

      //var row = db.Table<TestTable>().First();
      //Assert.AreEqual("one", row.ParamValue, "First value was not 'one'");

      conn.Close();
    }
  }
}