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
    public void InMemoryRawCreateTableTest()
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