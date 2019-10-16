/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-10-16
 * Author:  Damian Suess
 * File:    SqliteObjects.cs
 * Description:
 *
 */

namespace Test.UTSystemDataSqlite.Helpers
{
  public struct View
  {
    public string ViewName { get; set; }

    public string Definition { get; set; }

    public string Select { get; set; }
  }

  public struct PrimaryKey
  {
    public string KeyName { get; set; }

    public string ColumnName { get; set; }

    public string TableName { get; set; }
  }

  /// <summary>
  /// TABLE_NAME, INDEX_NAME, PRIMARY_KEY, [UNIQUE], [CLUSTERED], ORDINAL_POSITION, COLUMN_NAME, COLLATION as SORT_ORDER
  /// </summary>
  public struct Index
  {
    public string TableName { get; set; }
    public string IndexName { get; set; }
    public bool Unique { get; set; }
    public string Filter { get; set; }
    public bool Clustered { get; set; }
    public int OrdinalPosition { get; set; }
    public string ColumnName { get; set; }
    public SortOrderEnum SortOrder { get; set; }
  }

  public enum SortOrderEnum
  {
    ASC,
    DESC
  }

  public class Trigger
  {
    public string TableName { get; set; }

    public string Definition { get; set; }

    public string TriggerName { get; set; }
  }

  public class Table
  {
    public string TableName { get; set; }

    public string Schema { get; set; }

    public string Name { get; set; }
  }
}