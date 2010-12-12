using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FacebookSDKExamples
{
	public class Application
	{
		static void Main (string[] args)
		{
			try 
			{
				UIApplication.Main (args);
			}
			catch (Exception e)
			{
				Console.WriteLine ("Toplevel exception: {0}", e);
			}
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		// Your Facebook APP Id must be set before running this example
		// See http://www.facebook.com/developers/createapp.php
		const string kAppId = null; // REPLACE THIS!!!
			
		FacebookSdk.Facebook facebook;
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			if(string.IsNullOrEmpty(kAppId))
			{
				throw new Exception("Your Facebook Application Id must be set before running this example. "
					                    + "See http://www.facebook.com/developers/createapp.php");
			}
			
			facebook = new FacebookSdk.Facebook(kAppId);
			
			DemoAppViewController vc = new DemoAppViewController(facebook);
			// If you have defined a view, add it here
			window.AddSubview(vc.View);
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		public override void HandleOpenURL (UIApplication application, NSUrl url)
		{
			Console.WriteLine("HandleOpenURL");
			facebook.HandleOpenUrl(url);
		}
		
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}