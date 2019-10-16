/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-10-16
 * Author:  Damian Suess
 * File:    ColumnList.cs
 * Description:
 *
 */

using System.Collections.Generic;
using System.Text;

namespace Test.UTSystemDataSqlite.Helpers
{
  public class ColumnList : List<string>
  {
    public override string ToString()
    {
      StringBuilder formatter = new StringBuilder();
      foreach (string value in this)
      {
        if (!value.StartsWith("["))
        {
          formatter.Append("[");
          formatter.Append(value);
          formatter.Append("], ");
        }
        else
        {
          formatter.Append(value);
          formatter.Append(", ");
        }
      }
      if (formatter.Length > 3)
      {
        formatter.Remove(formatter.Length - 2, 2);
      }
      return formatter.ToString();
    }
  }
}