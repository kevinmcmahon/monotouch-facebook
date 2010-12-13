Monotouch bindings for the Facebook iOS SDK
===========================================

You can get the Facebook iOS code from their [github page](http://github.com/facebook/facebook-ios-sdk).

The FacebookSDKExamples directory has a working example of the DemoApp which was also ported from the Objective-C code.  This example shows the basics of logging in and illustrates some of the things you can do with the API.

NOTE: In order to run the DemoApp you'll first have to create a Facebook app from your Facebook account and set the kAppId variable to your own id.  See http://www.facebook.com/developers/createapp.php for more details.

Adding this lib to your project
-------------------------------

- copy libfacebook_ios_sdk.a to the root of your proj
- specify your FB appId in your Info.plist file. (see their [readme](https://github.com/facebook/facebook-ios-sdk/blob/master/README.mdown) for more info on how to do this)
- in your MonoTouch project options > iPhone Build
    - set Linker behavior to "Link SDK assemblies only"
    - set Extra arguments to:

          -v -v -v -gcc_flags "-L${ProjectDir} -lfacebook_ios_sdk -framework CoreGraphics -force_load ${ProjectDir}/libfacebook_ios_sdk.a"