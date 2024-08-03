# Overview

This repo teaches you how to implement the various C# SQLite NuGets for mobile development with Xamarin and .NET MAUI

We're focusing on regular SQLite and SQLCipher.

## Learn SQLite for .NET MAUI

To get started using SQLite in your own .NET MAUI project, you'll need the following NuGet packages. Yes, though it does say `*-pcl` it is not a PLC library

| Library | Author | Version |
|-|-|-|
| [sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl/)                        | SQLite-net | 1.8.116
| [SQLitePCLRaw.bundle_green](https://www.nuget.org/packages/SQLitePCLRaw.bundle_green/)  | Eric Sink  | 2.1.3

## SQLite Open Flags

`SQLiteOpenFlag`

| Flag | Description |
|-|-|
| Create | The connection will automatically create the database file if it doesn't exist.
| FullMutex | The connection is opened in serialized threading mode.
| NoMutex | The connection is opened in multi-threading mode.
| PrivateCache | The connection will not participate in the shared cache, even if it's enabled.
| ReadWrite | The connection can read and write data.
| SharedCache | The connection will participate in the shared cache, if it's enabled.
| ProtectionComplete | The file is encrypted and inaccessible while the device is locked.
| ProtectionCompleteUnlessOpen | The file is encrypted until it's opened but is then accessible even if the user locks the device.
| ProtectionCompleteUntilFirstUserAuthentication | The file is encrypted until after the user has booted and unlocked the device.
| ProtectionNone | The database file isn't encrypted.

## Learn Unit Testing SQLite Project

| Test | Active | Link |
|------|--------|------|
| Test.UTSqliteNet        | Yes | [NuGet](https://www.nuget.org/packages/sqlite-net-pcl) [GitHub](https://github.com/praeclarum/sqlite-net/) |
| Test.UTSqliteNetCipher  | Yes | [NuGet](https://www.nuget.org/packages/sqlite-net-sqlcipher) |
| Test.UTSqlitePcl        | *To Do* | [GitHub](https://github.com/ericsink/SQLitePCL.raw) |
| Test.UTAkavatch         | *To Do* | [NuGet](https://www.nuget.org/packages/akavache) [GitHub](https://github.com/reactiveui/Akavache) |

## About SQLite

Maintained by Eric Sink, this is a raw implementation for SQLite and is not recommended for novice users.

To use you'll need the following NuGet packages:

* `SQLitePCLRaw.core`
* `SQLitePCLRaw.provider.*`

### Notes from NuGet

SQLitePCL.raw is a Portable Class Library (PCL) for low-level (raw) access to SQLite.  This package does not provide an API which is friendly to app developers.  Rather, it provides an API which handles platform and configuration issues, upon which a friendlier API can be built.  In order to use this package, you will need to also add one of the `SQLitePCLRaw.provider.*` packages and call `raw.SetProvider()`.

Convenience packages are named `SQLitePCLRaw.bundle_*`.

## References

* [SQLite and .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/database-sqlite?view=net-maui-7.0#install-the-sqlite-nuget-package)
