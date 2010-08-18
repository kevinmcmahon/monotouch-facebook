
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FacebookSDKExamples
{
	public partial class FBButton : UIButton
	{
		UIImage _loginImage, _loginDownImage, _logoutImage, _logoutDownImage;
		bool _isLoggedIn;
		
		public bool IsLoggedIn 
		{
			get { 
				return _isLoggedIn; 
			}
			set {
				_isLoggedIn = value;
				UpdateImage();
			}
		}
		
		public FBButton()
		{
			Initialize();
		}
		
		public FBButton(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		
		void Initialize()
		{
			_loginImage = UIImage.FromBundle("Images/login.png");
			_loginDownImage = UIImage.FromBundle("Images/login_down.png");
			_logoutImage = UIImage.FromBundle("Images/logout.png");
			_logoutDownImage = UIImage.FromBundle("Images/logout_down.png");
			
			SetImage(_loginImage,UIControlState.Normal);
			SetImage(_loginDownImage,UIControlState.Selected);
		}
		
		void UpdateImage()
		{
			if(IsLoggedIn)
			{
				SetImage(_logoutImage, UIControlState.Normal);
				SetImage(_logoutDownImage, UIControlState.Selected);
			}
			else
			{
				SetImage(_loginImage, UIControlState.Normal);
				SetImage(_loginDownImage, UIControlState.Selected);
			}
		}
			
	}
}