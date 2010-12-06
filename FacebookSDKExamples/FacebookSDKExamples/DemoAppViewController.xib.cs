using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FacebookSdk;

namespace FacebookSDKExamples
{
	public partial class DemoAppViewController : UIViewController
	{
		
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public DemoAppViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public DemoAppViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public DemoAppViewController () : base("DemoAppViewController", null)
		{
			Initialize ();
		}
		
		// Your Facebook APP Id must be set before running this example
		// See http://www.facebook.com/developers/createapp.php
		const string kAppId = "146876642003167"; // REPLACE THIS!!!
		
		Facebook _facebook;
		RequestDelegate _requestDelegate;
		SessionDelegate _sessionDelegate;
		
		void Initialize ()
		{
			if(string.IsNullOrEmpty(kAppId))
				throw new Exception("Your Facebook Application Id must be set before running this example. "
				                    + "See http://www.facebook.com/developers/createapp.php");
			
			_facebook = new Facebook();
			_requestDelegate = new RequestDelegate(this);
			_sessionDelegate = new SessionDelegate(this);
		}
		
		#endregion
		public FBButton FacebookButton
		{
			get { return button; }
		}
		
		public UIButton UserInfoButton
		{
			get { return userInfoButton; }
		}
		
		public UIButton PublishButton
		{
			get { return publishButton; }
		}
		
		public UIButton PublicInfoButton
		{
			get { return publicInfoButton; }
		}
		
		public UIButton UploadPhotoButton
		{
			get { return uploadPhotoButton; }
		}
		
		public string Label
		{
			get { return label.Text; }
			set { label.Text = value; }
		}
		
		public override void ViewDidLoad() 
		{
			base.ViewDidLoad();
			
			Label = "Please log in";
			UserInfoButton.Hidden = true;
			PublishButton.Hidden = true;
			PublicInfoButton.Hidden = true;
			UploadPhotoButton.Hidden = true;
			FacebookButton.IsLoggedIn = false;
			
			FacebookButton.TouchDown += delegate {
				if(FacebookButton.IsLoggedIn)
					Logout();
				else
					Login();
			};
			
			UserInfoButton.TouchDown += delegate {
				 _facebook.RequestWithGraphPath("me", _requestDelegate);
			};
			
			PublicInfoButton.TouchDown += delegate {
				NSMutableDictionary parms = new NSMutableDictionary();
				parms.Add(new NSString("query"),new NSString("SELECT uid,name FROM user WHERE uid=4"));
				_facebook.RequestWithMethodName("fql.query",parms,"POST",_requestDelegate);
			};
			
			UploadPhotoButton.TouchDown += delegate {
 				var img = UIImage.FromBundle("Images/mono-65.png");
				NSMutableDictionary parms = new NSMutableDictionary();
				parms.Add(new NSString("picture"),img);
				_facebook.RequestWithMethodName("photos.upload",parms,"POST",_requestDelegate);
			};
			
			PublishButton.TouchDown += delegate {
			//	SBJSON *jsonWriter = [[SBJSON new] autorelease];
			//  
			//  NSDictionary* actionLinks = [NSArray arrayWithObjects:[NSDictionary dictionaryWithObjectsAndKeys: 
			//                               @"Always Running",@"text",@"http://itsti.me/",@"href", nil], nil];
			//  
			//  NSString *actionLinksStr = [jsonWriter stringWithObject:actionLinks];
			//  NSDictionary* attachment = [NSDictionary dictionaryWithObjectsAndKeys:
			//                               @"a long run", @"name",
			//                               @"The Facebook Running app", @"caption",
			//                               @"it is fun", @"description",
			//                               @"http://itsti.me/", @"href", nil];
			//  NSString *attachmentStr = [jsonWriter stringWithObject:attachment];
			//  NSMutableDictionary* params = [NSMutableDictionary dictionaryWithObjectsAndKeys:
			//                                 kAppId, @"api_key",
			//                                 @"Share on Facebook",  @"user_message_prompt",
			//                                 actionLinksStr, @"action_links",
			//                                 attachmentStr, @"attachment",
			//                                 nil];
			//  
			//  
			//  [_facebook dialog: @"stream.publish"
			//          andParams: params
			//        andDelegate:self];
			};
		}
		
		void Login()
		{
			_facebook.Authorize(kAppId, new []{"read_stream", "offline_access"}, _sessionDelegate);
		}

		void Logout()
		{
			_facebook.Logout(_sessionDelegate);	 
		}
		
		public void SetText(string text)
		{
			this.Label = text;
		}
	}
	
	public class SessionDelegate : FBSessionDelegate
	{
		DemoAppViewController _vc;
		
		public SessionDelegate(DemoAppViewController vc)
		{
			_vc = vc;
		}
		
		public override void FbDidLogin()
		{
			Console.WriteLine("FbDidLogin");
			_vc.SetText("logged in");
			_vc.UserInfoButton.Hidden = false;
			_vc.PublishButton.Hidden = false;
			_vc.PublicInfoButton.Hidden = false;
			_vc.UploadPhotoButton.Hidden = false;
			_vc.FacebookButton.IsLoggedIn = true;
		}
		
		public override void FbDidLogout()
		{
			Console.WriteLine("FbDidLogout");
			_vc.SetText("Please log in");
			_vc.UserInfoButton.Hidden = true;
			_vc.PublishButton.Hidden = true;
			_vc.PublicInfoButton.Hidden = true;
			_vc.UploadPhotoButton.Hidden = true;
			_vc.FacebookButton.IsLoggedIn = false;
		}
		
		public override void FbDidNotLogin(bool cancelled)
		{
			Console.WriteLine("FB Did Not Login");
		}
	}
	
	public class RequestDelegate : FBRequestDelegate
	{
		DemoAppViewController _vc;
		
		public RequestDelegate(DemoAppViewController vc)
		{
			_vc = vc;
		}
		
		public override void RequestLoading(FBRequest request)
		{}
		
		public override void Request (FBRequest request, NSUrlResponse response)
		{
		}
		
		public override void Request (FBRequest request, NSError error)
		{
		}
		
		public override void Request (FBRequest request, NSObject result)
		{
			NSDictionary dict;
			
			if(result is NSDictionary)
			{	
				dict = result as NSDictionary;
			}
			else if(result is NSArray)
			{
				var arr = (NSArray)result;
				dict = new NSDictionary(arr.ValueAt(0));
			}
			else
			{
				throw new Exception("cannot handle result in FBRequestDelegate callback");
			}
			
			if (dict.ObjectForKey(new NSString("owner")) != null)
		    {
			     _vc.SetText("Photo upload Success");
			}
			else 
			{
				NSObject name =	dict.ObjectForKey(new NSString("name"));
			    _vc.SetText(name.ToString());
			}
		}
	
		public override void Request (FBRequest request, NSData data)
		{}
	}
	
	public class DialogDelegate : FBDialogDelegate
	{
		DemoAppViewController _vc;
		
		public DialogDelegate(DemoAppViewController vc)
		{
			_vc = vc;
		}
		
		public override void DialogDidComplete (FBDialog dialog)
		{
			_vc.SetText("publish was successful");	
		}
		
		public override void DialogCompleteWithUrl (NSUrl url)
		{
		}
		
		public override void DialogDidNotComplete (FBDialog dialog)
		{
		}
		
		public override void DialogDidNotCompleteWithUrl (NSUrl url)
		{
		}
		
		public override void Dialog (FBDialog dialog, NSError error)
		{
		}
		
		public override bool Dialog (FBDialog dialog, NSUrl url)
		{
			return true;
		}
	}
}