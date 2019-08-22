# Overview
Tests the various C# SQLite NuGets for mobile development with Xamarin

We're focusing on regular SQLite and with SQLCipher.

## Types of Tests

| Test | Active | Link |
|------|--------|------|
| Test.UTSqliteNet        | Yes | [NuGet]](https://www.nuget.org/packages/sqlite-net-pcl) [GitHub](https://github.com/praeclarum/sqlite-net/) |
| Test.UTSqliteNetCipher  | Yes | [NuGet](https://www.nuget.org/packages/sqlite-net-sqlcipher) |
| Test.UTSqlitePcl        | *ToDo* | [GitHub](https://github.com/ericsink/SQLitePCL.raw) |
| Test.UTAkavatch         | *ToDo* | [NuGet](https://www.nuget.org/packages/akavache) [GitHub](https://github.com/reactiveui/Akavache) |

## SQLiteNet


## SQLitePCLRaw
Maintained by Eric Sink, this is a raw implementation for SQLite and is not recommended for novice users.

To use you'll need the following NuGet packages:
* SQLitePCLRaw.core
* SQLitePCLRaw.provider.*


### Notes from NuGet
SQLitePCL.raw is a Portable Class Library (PCL) for low-level (raw) access to SQLite.  This package does not provide an API which is friendly to app developers.  Rather, it provides an API which handles platform and configuration issues, upon which a friendlier API can be built.  In order to use this package, you will need to also add one of the SQLitePCLRaw.provider.* packages and call raw.SetProvider().  Convenience packages are named SQLitePCLRaw.bundle_*.

