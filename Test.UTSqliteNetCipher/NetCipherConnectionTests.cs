using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UTSqliteNetCipher
{
  [TestClass]
  public class NetCipherConnectionTests
  {
    [TestMethod]
    public void CanCreateDatabaseTest()
    {
      string path = @"C:\temp\test-net.db";

      if (System.IO.File.Exists(path))
        System.IO.File.Delete(path);

      var conn = new SQLite.SQLiteAsyncConnection(path);

      bool exists = System.IO.File.Exists(path);

      Assert.AreEqual(true, exists, "Could not generate db");

      conn.CloseAsync();
    }
  }
}
