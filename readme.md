# Overview
Tests the various SQLite NuGets for mobile (Xamarin) development

## Types of Tests

| Test | Active | Link |
|------|--------|------|
| Test.UTSqliteNet        | Yes | https://github.com/praeclarum/sqlite-net/ |
| Test.UTSqliteNetCipher  | 50% | https://www.nuget.org/packages/sqlite-net-sqlcipher |
| Test.UTSqlitePcl        | ToDo | https://github.com/ericsink/SQLitePCL.raw |


## Dev Notes
* Classic
    * Good for large file transfers
    * Eats battery life
* Bluetooth LE
    * Can only send 20b packets at a time. Yes, bytes! Great for small packets, not large transfers


## References

### Android
* [How to detect BT devices - Xamain.Android](https://jeremylindsayni.wordpress.com/2018/12/16/how-to-detect-nearby-bluetooth-devices-with-net-and-xamarin-android/)
    * [github example](https://github.com/jeremylindsayni/Xamarin.Android.BluetoothDeviceScanner)
* [XF Barcode scanner](https://acaliaro.wordpress.com/2017/02/07/connect-a-barcode-reader-to-a-xamarin-forms-app-via-bluetooth/)
    * https://github.com/acaliaro/TestBth

### UWP
* https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BluetoothRfcommChat
* https://forums.xamarin.com/discussion/149314/bluetooth-classic-example-with-xamarin-for-uwp-rfcomm

### Misc
* [Control RPI with Xamarin.BT](https://blog.iamlevi.net/2017/05/control-raspberry-pi-android-bluetooth/)
    * https://github.com/levifuksz/raspibt
