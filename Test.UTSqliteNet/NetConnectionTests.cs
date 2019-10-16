/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-17
 * Author:  Damian Suess
 * File:    NetConnectionTests.cs
 * Description:
 *  Example for the "sqlite-net-pcl" NuGet package by Frank A. Krueger
 *
 * Main Package:
 *  - sqlite-net-pcl v1.5.231
 *
 * Dependency Package
 *  - SQLitePCL v1.1.11
 *  ** DO NOT UPGRADE to v2.0 at this time. It will break!
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;

namespace Test.UTSqliteNet
{
  [TestClass]
  public class NetConnectionTests
  {
    private const string Path = @"C:\temp\test-net-regular.db";

    [TestInitialize]
    public void CleanupBeforeTests()

    {
      //using (var conn = new SQLiteConnection(":memory:", true))
      //{
      //  conn.Execute("PRAGMA cipher_default_use_hmac = ON;");
      //}
    }

    [TestCleanup]
    public void CleanupPostTests()
    {
      // This think does not work with Async connections because it's still
      // open when we get here.
      //
      //System.IO.File.Delete(Path);
      //
      //Assert.AreEqual(
      //  false,
      //  System.IO.File.Exists(Path),
      //  "Failed to remove temp db file");
    }

    [TestMethod]
    public void CanCreateDatabaseTest()
    {
      if (System.IO.File.Exists(Path))
        System.IO.File.Delete(Path);

      var conn = new SQLite.SQLiteAsyncConnection(Path);

      bool exists = System.IO.File.Exists(Path);
      Assert.AreEqual(true, exists, "Could not generate db");

      conn.CloseAsync();
    }

    [TestMethod]
    public void InMemoryConnectionTest()
    {
      // open an in memory connection and reset SQLCipher default pragma settings
      using (var db = new SQLiteConnection(":memory:", true))
      {
        db.CreateTable<TestTable>();
        db.Insert(new TestTable { ParamValue = "Test Item" });

        var row = db.Table<TestTable>().First();

        Assert.AreEqual("Test Item", row.ParamValue);
      }
    }

    [TestMethod]
    public void InMemory_RawCreate_AllTables_Test()
    {
      // open an in memory connection and reset SQLCipher default pragma settings
      using (var db = new SQLiteConnection(":memory:", true))
      {
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

    [TestMethod]
    public void InMemory_RawCreate_SingleTables_Test()
    {
      // open an in memory connection and reset SQLCipher default pragma settings
      using (var db = new SQLiteConnection(":memory:", true))
      {
        db.Execute("CREATE TABLE TestTable (Id INT, ParamValue VARCHAR(32));");
        db.Execute("INSERT INTO TestTable (Id, ParamValue) VALUES (1, 'one');");
        db.Execute("INSERT INTO TestTable (Id, ParamValue) VALUES (2, 'two');");

        var cnt = db.ExecuteScalar<int>("SELECT COUNT(*) FROM TestTable;");
        Assert.AreEqual(2, cnt, "Invalid row count");

        var row = db.Table<TestTable>().First();
        Assert.AreEqual("one", row.ParamValue, "First value was not 'one'");
      }
    }

    private class TestTable
    {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string ParamValue { get; set; }
    }
  }
}