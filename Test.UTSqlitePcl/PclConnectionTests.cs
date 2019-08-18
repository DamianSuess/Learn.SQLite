/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-17
 * Author:  Damian Suess
 * File:    PclConnectionTests.cs
 * Description:
 *  Example for the SQLitePCLRaw NuGet package
 *  
 *  Work in progress; none of this code is useful yet.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLitePCL;

namespace Test.UTSqlitePcl
{
  [TestClass]
  public class PclConnectionTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      Batteries_V2.Init();
    }
  }
}