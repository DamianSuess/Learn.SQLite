/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-17
 * Author:  Damian Suess
 * File:    NetCipherConnectionTests.cs
 * Description:
 *  Example for the "sqlite-net-pcl-cipher" NuGet package by Frank A. Krueger
 *
 * Examples:
 *  - https://github.com/praeclarum/sqlite-net/blob/master/tests/SQLCipherTest.cs
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;

namespace Test.UTSqliteNetCipher
{
  [TestClass]
  public class NetCipherConnectionTests
  {
    private const string Path = @"C:\temp\test-net-cipher.db";
    private const string EncryptionKey = "testing";

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
      //System.IO.File.Delete(Path);
      //
      //Assert.AreEqual(
      //  false,
      //  System.IO.File.Exists(Path),
      //  "Failed to remove temp db file");
    }

    [TestMethod]
    public void ConnectionTest()
    {
      // open an in memory connection and reset SQLCipher default pragma settings
      using (var db = new SQLiteConnection(":memory:", true, EncryptionKey))
      {
        db.Execute("PRAGMA cipher_default_use_hmac = ON;");

        db.CreateTable<TestTable>();
        db.Insert(new TestTable { Value = "Test Item" });

        var row = db.Table<TestTable>().First();

        Assert.AreEqual(row.Value, "Test Item");
      }
    }

    [TestMethod]
    public void CanCreateDatabaseTest()
    {
      if (System.IO.File.Exists(Path))
        System.IO.File.Delete(Path);

      SQLitePCL.Batteries_V2.Init();
      var db = new SQLite.SQLiteAsyncConnection(Path, true, EncryptionKey);

      bool exists = System.IO.File.Exists(Path);
      Assert.AreEqual(true, exists, "Could not generate db");

      db.CloseAsync();
    }

    [TestMethod]
    public void SetBadBytesKeyTest()
    {
      try
      {
        using (var db = new SQLiteConnection(Path, key: new byte[] { 1, 2, 3, 4 }))
        {
        }

        Assert.Fail("Should have thrown");
      }
      catch (ArgumentException)
      {
      }
    }

    private class TestTable
    {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string Value { get; set; }
    }
  }
}