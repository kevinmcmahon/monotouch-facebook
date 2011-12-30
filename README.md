# Update: The [Mono Project](https://github.com/mono/) has been maintaining a [set of bindings](https://github.com/mono/monotouch-bindings/tree/master/FacebookConnect)
. I'm leaving the repo but will not be making any future revisions.

Monotouch bindings for the Facebook iOS SDK
===========================================

I've [forked the official Facebook iOS SDK](https://github.com/kevinmcmahon/facebook-ios-sdk) and made two key changes. The first was to turn off THUMB code generation so the static library code be linked to successfully by MonoTouch and the second change was to create a "fat" static library. Having a single library that could be used on the device or with the sim simplifies things as you don't have to make sure you're linking/using the right binary.

The FacebookSDKExamples directory has a working example of the DemoApp which was also ported from the Objective-C code.  This example shows the basics of logging in and illustrates some of the things you can do with the API.

NOTE: In order to run the DemoApp you'll first have to create a Facebook app from your Facebook account and set the kAppId variable to your own id.  See http://www.facebook.com/developers/createapp.php for more details.

Adding this lib to your project
-------------------------------

- Copy libfacebook_ios_sdk.a to the root of your proj
- Specify your FB appId in your Info.plist file. (see their [readme](https://github.com/facebook/facebook-ios-sdk/blob/master/README.mdown) for more info on how to do this)
- In your MonoTouch project options > iPhone Build
    - Set Linker behavior to "Link SDK assemblies only"
    - Set the Extra arguments in all iPhone Build configurations to:

          -v -gcc_flags "-L${ProjectDir} -lfacebook_ios_sdk -framework CoreGraphics -force_load ${ProjectDir}/libfacebook_ios_sdk.a"
      
      This includes build configs for Debug and Release versions of iPhone and iPhoneSimulator configs.