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
      string connString = "";

      SQLiteConnection conn = new SQLiteConnection(connString);
      conn.Open();

      SQLiteCommand cmd = new SQLiteCommand(conn);
      cmd.CommandText = "CREATE TABLE Blarg";

      // open an in memory connection and reset SQLCipher default pragma settings

      db.Execute(@"
CREATE TABLE TestTable1 (Id INT, ParamValue VARCHAR(32));
CREATE TABLE TestTable2 (Id INT, ParamValue VARCHAR(32));

INSERT INTO TestTable1 (Id, ParamValue) VALUES (1, 'one');
INSERT INTO TestTable1 (Id, ParamValue) VALUES (2, 'two');

INSERT INTO TestTable2 (Id, ParamValue) VALUES (1, 'one');
INSERT INTO TestTable2 (Id, ParamValue) VALUES (2, 'two');
");

      int cnt = 0;
      cnt = db.ExecuteScalar<int>("SELECT COUNT(*) FROM TestTable1;");
      Assert.AreEqual(2, cnt, "Table-1 Invalid row count");

      cnt = db.ExecuteScalar<int>("SELECT COUNT(*) FROM TestTable2;");
      Assert.AreEqual(2, cnt, "Table-2 Invalid row count");

      var row = db.Table<TestTable>().First();
      Assert.AreEqual("one", row.ParamValue, "First value was not 'one'");
    }
  }
}
}