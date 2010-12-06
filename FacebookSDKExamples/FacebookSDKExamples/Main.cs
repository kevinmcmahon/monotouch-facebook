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
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			DemoAppViewController vc = new DemoAppViewController();
			// If you have defined a view, add it here
			window.AddSubview(vc.View);
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}