/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-9-11
 * Author:  Damian Suess
 * File:    SqliteDeepTests.cs
 * Description:
 *  SQLite-net-pcl tests
 *
 * References:
 *  - SQLiteNet doesn't have a SQLiteDataAdapter  (i.e. https://www.codeproject.com/Articles/17966/SQLite-GUI)
 *  - SQLiteNet doesn't let you use Read()  (i.e. https://github.com/aspnet/Microsoft.Data.Sqlite/blob/17e4cd22d7c43c721eb51925ab0864187fa3ffd0/samples/AggregateFunctionSample/Program.cs)
 *
 * Others:
 *  - https://github.com/jstedfast/MimeKit/blob/master/Mono.Data.Sqlite/SQLiteDataAdapter.cs
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;

namespace Test.SQLiteX
{
  [TestClass]
  public class SqliteDeepTests
  {
    private SQLiteConnection _db;

    [TestInitialize]
    public void CleanupBeforeTest()
    {
      _db = new SQLiteConnection(":memory:");
      // var cmd = new SQLiteCommand(_sql);
    }

    [TestCleanup]
    public void CleanupPostTest()
    {
      if (_db != null)
      {
        try
        {
        }
        catch (Exception)
        {
          _db.Close();
        }
      }
    }

    [TestMethod]
    public void RawQueryTest()
    {
      using (var db = new SQLiteConnection(":memory:", true))
      {
        db.Execute("CREATE TABLE TestTable (Id INT, ParamValue VARCHAR(32));");

        string query = @"
          INSERT INTO TestTable(Id, ParamValue) VALUES(1, 'one');
          INSERT INTO TestTable (Id, ParamValue) VALUES (2, 'two');
        ";
        var cmd = db.CreateCommand(query);
        cmd.ExecuteNonQuery();

        query = @"SELECT * FROM TestTable";
        var x = db.Query<object>(query);

        Assert.IsTrue(x.Count > 0);

        // Raw SQLite uses the statement below
        //var reader = cmd.ExecuteReader();
        //while (reader.Read())
        //{
        //  Console.WriteLine($"{reader["name"]}: {reader["volume"]}");
        //}
      }
    }

    [TestMethod]
    public void CreateSimpleTableTest()
    {
      using (var db = new SQLiteConnection(":memory:", true))
      {
        db.CreateTable<TestTable>();

        db.Insert(new TestTable { SomeInt = 1, MyParameter = "Hello", ParamValue = "one" });
        db.Insert(new TestTable { SomeInt = 2, MyParameter = "There", ParamValue = "two" });

        string query = @"SELECT * FROM TestTable";

        var ret1 = db.Query<TestTable>(query);

        Assert.IsTrue(ret1.Count > 0);

        foreach (var item in ret1)
        {
          Assert.IsTrue(item.MyParameter.Length > 0);
          System.Diagnostics.Debug.WriteLine("1> " + item.MyParameter);
        }
      }
    }

    private void CreateSimpleTable()
    {
      using (var db = new SQLiteConnection(":memory:", true))
      {
        db.Execute("CREATE TABLE TestTable (Id INT, ParamValue VARCHAR(32));");

        string query = @"
          INSERT INTO TestTable(Id, ParamValue) VALUES(1, 'one');
          INSERT INTO TestTable (Id, ParamValue) VALUES (2, 'two');
        ";
        var cmd = db.CreateCommand(query);
        cmd.ExecuteNonQuery();
      }
    }
  }
}