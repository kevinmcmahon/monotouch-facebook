//
//  MonoTouch bindings for Facebook iOS SDK 
//  use with libfacebook_ios_sdk.a  
//
//  Facebook Objective-C Source : http://github.com/facebook/facebook-ios-sdk
//
//  MIT X11 licensed
//
// Copyright 2010 Kevin McMahon (http://twitter.com/klmcmahon)
//

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace FacebookSdk
{
	[BaseType(typeof(NSObject))]
	interface Facebook
	{

		//- (void) authorize:(NSString*) application_id permissions:(NSArray*) permissions delegate:(id<FBSessionDelegate>) delegate;
		[Export("authorize:permissions:delegate:")]
		void Authorize (string application_id, string[] permissions, FBSessionDelegate fbSessionDelegate);

		//- (void) logout:(id<FBSessionDelegate>) delegate;
		[Export("logout:")]
		void Logout (FBSessionDelegate fbSessionDelegate);

		//- (void) requestWithParams:(NSMutableDictionary *) params andDelegate:(id <FBRequestDelegate>) delegate;
		[Export("requestWithParams:andDelegate:")]
		void RequestWithParams (NSDictionary parms, FBRequestDelegate fbRequestDelegate);

		//- (void) requestWithMethodName:(NSString *) methodName andParams:(NSMutableDictionary *) params andHttpMethod:(NSString *) httpMethod andDelegate:(id <FBRequestDelegate>) delegate;
		[Export("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		void RequestWithMethodName (string methodName, NSDictionary parms, string httpMethod, FBRequestDelegate fbRequestDelegate);

		//- (void) requestWithGraphPath:(NSString *) graphPath andDelegate:(id <FBRequestDelegate>) delegate;
		[Export("requestWithGraphPath:andDelegate:")]
		void RequestWithGraphPath (string graphPath, FBRequestDelegate fbRequestDelegate);

		//- (void) requestWithGraphPath:(NSString *)graphPath andParams:(NSMutableDictionary *) params andDelegate:(id <FBRequestDelegate>) delegate;
		[Export("requestWithGraphPath:andParams:andDelegate:")]
		void RequestWithGraphPath (string graphPath, NSDictionary parms, FBRequestDelegate fbRequestDelegate);

		//- (void) requestWithGraphPath:(NSString *)graphPath andParams:(NSMutableDictionary *) params andHttpMethod:(NSString *) httpMethod andDelegate:(id <FBRequestDelegate>) delegate;
		[Export("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		void RequestWithGraphPath (string graphPath, NSDictionary parms, string httpMethod, FBRequestDelegate fbRequestDelegate);

		//- (void) dialog:(NSString *) action andDelegate:(id<FBDialogDelegate>) delegate;
		[Export("dialog:andDelegate:")]
		void Dialog (string action, FBDialogDelegate fbDialogDelegate);

		//- (void) dialog:(NSString *) action andParams:(NSMutableDictionary *) params andDelegate:(id <FBDialogDelegate>) delegate;
		[Export("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSDictionary parms, FBDialogDelegate fbDialogDelegate);

		//- (BOOL) isSessionValid;
		[Export("isSessionValid")]
		bool IsSessionValid { get; }
		
	}

	[Model]
	[BaseType(typeof(NSObject))]
	interface FBSessionDelegate
	{

		//@optional- (void)fbDidLogin;
		[Abstract, Export("fbDidLogin")]
		void FbDidLogin ();

		//- (void)fbDidNotLogin:(BOOL)cancelled;
		[Abstract, Export("fbDidNotLogin:")]
		void FbDidNotLogin (bool cancelled);

		//- (void)fbDidLogout;
		[Abstract, Export("fbDidLogout")]
		void FbDidLogout ();
		
	}

	[BaseType(typeof(NSObject))]
	interface FBRequest
	{

		// requestURL:(NSString *) url;
		[Export("url")]
		string Url { get; }

		//- (BOOL) loading;
		[Export("loading")]
		bool Loading { get; }

		//- (void) connect;
		[Export("connect")]
		void Connect ();
		
	}

	[Model]
	[BaseType(typeof(NSObject))]
	interface FBRequestDelegate
	{

		//@optional- (void)requestLoading:(FBRequest*)request;
		[Abstract, Export("requestLoading:")]
		void RequestLoading (FBRequest request);

		//- (void)request:(FBRequest*)request didReceiveResponse:(NSURLResponse*)response;
		[Abstract, Export("request:didReceiveResponse:")]
		void Request (FBRequest request, NSUrlResponse response);

		//- (void)request:(FBRequest*)request didFailWithError:(NSError*)error;
		[Abstract, Export("request:didFailWithError:")]
		void Request (FBRequest request, NSError error);

		//- (void)request:(FBRequest*)request didLoad:(id)result;
		[Abstract, Export("request:didLoad:")]
		void Request (FBRequest request, NSObject result);

		//- (void)request:(FBRequest*)request didLoadRawResponse:(NSData*)data;
		[Abstract, Export("request:didLoadRawResponse:")]
		void Request (FBRequest request, NSData data);
		
	}

	[BaseType(typeof(UIView))]
	interface FBDialog
	{

		//- (NSString *) getStringFromUrl: (NSString*) url needle:(NSString *) needle;
		[Export("getStringFromUrl:needle:")]
		string GetStringFromUrl (string url, string needle);

		//         delegate: (id <FBDialogDelegate>) delegate;
		[Export("delegate")]
		FBDialog Delegate { get; }

		//- (void)show;
		[Export("show")]
		void Show ();

		//- (void)load;
		[Export("load")]
		void Load ();

		// get:(NSDictionary*)getParams;
		[Export("getParams")]
		NSDictionary GetParams { get; }

		//- (void)dismissWithSuccess:(BOOL)success animated:(BOOL)animated;
		[Export("dismissWithSuccess:animated:")]
		void DismissWithSuccess (bool success, bool animated);

		//- (void)dismissWithError:(NSError*)error animated:(BOOL)animated;
		[Export("dismissWithError:animated:")]
		void DismissWithError (NSError error, bool animated);

		//- (void)dialogWillAppear;
		[Export("dialogWillAppear")]
		void DialogWillAppear ();

		//- (void)dialogWillDisappear;
		[Export("dialogWillDisappear")]
		void DialogWillDisappear ();

		//- (void)dialogDidSucceed:(NSURL *)url;
		[Export("dialogDidSucceed:")]
		void DialogDidSucceed (NSUrl url);

		//- (void)dialogDidCancel:(NSURL *)url;
		[Export("dialogDidCancel:")]
		void DialogDidCancel (NSUrl url);
		
	}

	[Model]
	[BaseType(typeof(NSObject))]
	interface FBDialogDelegate
	{

		//@optional- (void)dialogDidComplete:(FBDialog *)dialog;
		[Abstract, Export("dialogDidComplete:")]
		void DialogDidComplete (FBDialog dialog);

		//- (void)dialogCompleteWithUrl:(NSURL *)url;
		[Abstract, Export("dialogCompleteWithUrl:")]
		void DialogCompleteWithUrl (NSUrl url);

		//- (void)dialogDidNotCompleteWithUrl:(NSURL *)url;
		[Abstract, Export("dialogDidNotCompleteWithUrl:")]
		void DialogDidNotCompleteWithUrl (NSUrl url);

		//- (void)dialogDidNotComplete:(FBDialog *)dialog;
		[Abstract, Export("dialogDidNotComplete:")]
		void DialogDidNotComplete (FBDialog dialog);

		//- (void)dialog:(FBDialog*)dialog didFailWithError:(NSError *)error;
		[Abstract, Export("dialog:didFailWithError:")]
		void Dialog (FBDialog dialog, NSError error);

		//- (BOOL)dialog:(FBDialog*)dialog shouldOpenURLInExternalBrowser:(NSURL *)url;
		[Abstract, Export("dialog:shouldOpenURLInExternalBrowser:")]
		bool Dialog (FBDialog dialog, NSUrl url);
		
	}

	[BaseType(typeof(FBDialog))]
	interface FBLoginDialog
	{

		// delegate:(id <FBLoginDialogDelegate>) delegate;
		[Export("delegate")]
		FBLoginDialog Delegate { get; }
	}

	[Model]
	[BaseType(typeof(NSObject))]
	interface FBLoginDialogDelegate
	{

		//- (void) fbDialogLogin:(NSString *) token expirationDate:(NSDate *) expirationDate;
		[Abstract, Export("fbDialogLogin:expirationDate:")]
		void FbDialogLogin (string token, NSDate expirationDate);

		//- (void) fbDialogNotLogin:(BOOL) cancelled;
		[Abstract, Export("fbDialogNotLogin:")]
		void FbDialogNotLogin (bool cancelled);
		
	}
}
