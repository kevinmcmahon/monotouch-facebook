//
//  MonoTouch bindings for Facebook iOS SDK 
//  use with libfacebook_ios_sdk.a  
//
//  Facebook Objective-C Source w/ MonoTouch modifications :
//  https://github.com/kevinmcmahon/facebook-ios-sdk
//
//  MIT X11 licensed
//
// Copyright 2010 Kevin McMahon (http://twitter.com/klmcmahon)
// 
// These bindings are for:
// https://github.com/kevinmcmahon/facebook-ios-sdk/commit/7f64bc25b2d2b03a3f17586988bbc80cd731ffc1

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace FacebookSdk
{

	[BaseType (typeof (NSObject))]
	interface Facebook {

		//- (id)initWithAppId:(NSString *)app_id;
		[Export ("initWithAppId:")]
		IntPtr Constructor (string app_id);

		//- (void)authorize:(NSArray *)permissions delegate:(id<FBSessionDelegate>)delegate;
		[Export ("authorize:delegate:")]
		void Authorize (string[] permissions, FBSessionDelegate fbSessionDelegate);

		// delegate:(id<FBSessionDelegate>)delegate;
		[Export ("delegate")]
		Facebook Delegate { get; }
		
		//@property(nonatomic, copy) NSString* accessToken;
		[Export ("accessToken", ArgumentSemantic.Copy)]
		string AccessToken { get; set;  }

		//@property(nonatomic, copy) NSDate* expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; set;  }
				
		//- (BOOL)handleOpenURL:(NSURL *)url;
		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);

		//- (void)logout:(id<FBSessionDelegate>)delegate;
		[Export ("logout:")]
		void Logout (FBSessionDelegate fbSessionDelegate);

		//- (void)requestWithParams:(NSMutableDictionary *)params andDelegate:(id <FBRequestDelegate>)delegate;
		[Export ("requestWithParams:andDelegate:")]
		void RequestWithParams (NSDictionary parms, FBRequestDelegate fbRequestDelegate);

		//- (void)requestWithMethodName:(NSString *)methodName andParams:(NSMutableDictionary *)params andHttpMethod:(NSString *)httpMethod andDelegate:(id <FBRequestDelegate>)delegate;
		[Export ("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		void RequestWithMethodName (string methodName, NSDictionary parms, string httpMethod, FBRequestDelegate fbRequestDelegate);

		//- (void)requestWithGraphPath:(NSString *)graphPath andDelegate:(id <FBRequestDelegate>)delegate;
		[Export ("requestWithGraphPath:andDelegate:")]
		void RequestWithGraphPath (string graphPath, FBRequestDelegate fbRequestDelegate);

		//- (void)requestWithGraphPath:(NSString *)graphPath andParams:(NSMutableDictionary *)params andDelegate:(id <FBRequestDelegate>)delegate;
		[Export ("requestWithGraphPath:andParams:andDelegate:")]
		void RequestWithGraphPath (string graphPath, NSDictionary parms, FBRequestDelegate fbRequestDelegate);

		//- (void)requestWithGraphPath:(NSString *)graphPath andParams:(NSMutableDictionary *)params andHttpMethod:(NSString *)httpMethod andDelegate:(id <FBRequestDelegate>)delegate;
		[Export ("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		void RequestWithGraphPath (string graphPath, NSDictionary parms, string httpMethod, FBRequestDelegate fbRequestDelegate);

		//- (void)dialog:(NSString *)action andDelegate:(id<FBDialogDelegate>)delegate;
		[Export ("dialog:andDelegate:")]
		void Dialog (string action, FBDialogDelegate fbDialogDelegate);

		//- (void)dialog:(NSString *)action andParams:(NSMutableDictionary *)params andDelegate:(id <FBDialogDelegate>)delegate;
		[Export ("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSDictionary parms, FBDialogDelegate fbDialogDelegate);

		//- (BOOL)isSessionValid;
		[Export ("isSessionValid")]
		bool IsSessionValid { get; }

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface FBSessionDelegate {

		//@optional- (void)fbDidLogin;
		[Abstract, Export ("fbDidLogin")]
		void FbDidLogin ();

		//- (void)fbDidNotLogin:(BOOL)cancelled;
		[Abstract, Export ("fbDidNotLogin:")]
		void FbDidNotLogin (bool cancelled);

		//- (void)fbDidLogout;
		[Abstract, Export ("fbDidLogout")]
		void FbDidLogout ();

	}

	[BaseType (typeof (NSObject))]
	interface FBRequest {

		//+ (NSString*)serializeURL:(NSString *)baseUrl params:(NSDictionary *)params;
		[Static, Export ("serializeURL:params:")]
		string SerializeUrl (string baseUrl, NSDictionary parms);

		//+ (NSString*)serializeURL:(NSString *)baseUrl params:(NSDictionary *)params httpMethod:(NSString *)httpMethod;
		[Static, Export ("serializeURL:params:httpMethod:")]
		string SerializeUrl (string baseUrl, NSDictionary parms, string httpMethod);

		//+ (FBRequest*)getRequestWithParams:(NSMutableDictionary *) params httpMethod:(NSString *) httpMethod delegate:(id<FBRequestDelegate>)delegate requestURL:(NSString *) url;
		[Static, Export ("getRequestWithParams:httpMethod:delegate:requestURL:")]
		FBRequest GetRequestWithParams (NSDictionary parms, string httpMethod, FBRequestDelegate fbRequestDelegate, string url);

		//- (BOOL) loading;
		[Export ("loading")]
		bool Loading { get; }

		//- (void) connect;
		[Export ("connect")]
		void Connect ();

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface FBRequestDelegate {

		//@optional- (void)requestLoading:(FBRequest *)request;
		[Abstract, Export ("requestLoading:")]
		void RequestLoading (FBRequest request);

		//- (void)request:(FBRequest *)request didReceiveResponse:(NSUrlResponse *)response;
		[Abstract, Export ("request:didReceiveResponse:")]
		void Request (FBRequest request, NSUrlResponse response);

		//- (void)request:(FBRequest *)request didFailWithError:(NSError *)error;
		[Abstract, Export ("request:didFailWithError:")]
		void Request (FBRequest request, NSError error);

		//- (void)request:(FBRequest *)request didLoad:(id)result;
		[Abstract, Export ("request:didLoad:")]
		void Request (FBRequest request, NSObject result);

		//- (void)request:(FBRequest *)request didLoadRawResponse:(NSData *)data;
		[Abstract, Export ("request:didLoadRawResponse:")]
		void Request (FBRequest request, NSData data);

	}

	[BaseType (typeof (UIView))]
	interface FBDialog {

		//- (NSString *) getStringFromUrl: (NSString*) url needle:(NSString *) needle;
		[Export ("getStringFromUrl:needle:")]
		string GetStringFromUrl (string url, string needle);

		//- (id)initWithURL: (NSString *) loadingURL params: (NSMutableDictionary *) params delegate: (id <FBDialogDelegate>) delegate;
		[Export ("initWithURL:params:delegate:")]
		IntPtr Constructor (string loadingURL, NSDictionary parms, FBDialogDelegate fbDialogDelegate);

		//- (void)show;
		[Export ("show")]
		void Show ();

		//- (void)load;
		[Export ("load")]
		void Load ();

		//- (void)loadURL:(NSString*)url get:(NSDictionary*)getParams;
		[Export ("loadURL:get:")]
		void LoadUrl (string url, NSDictionary getParams);

		//- (void)dismissWithSuccess:(BOOL)success animated:(BOOL)animated;
		[Export ("dismissWithSuccess:animated:")]
		void DismissWithSuccess (bool success, bool animated);

		//- (void)dismissWithError:(NSError*)error animated:(BOOL)animated;
		[Export ("dismissWithError:animated:")]
		void DismissWithError (NSError error, bool animated);

		//- (void)dialogWillAppear;
		[Export ("dialogWillAppear")]
		void DialogWillAppear ();

		//- (void)dialogWillDisappear;
		[Export ("dialogWillDisappear")]
		void DialogWillDisappear ();

		//- (void)dialogDidSucceed:(NSURL *)url;
		[Export ("dialogDidSucceed:")]
		void DialogDidSucceed (NSUrl url);

		//- (void)dialogDidCancel:(NSURL *)url;
		[Export ("dialogDidCancel:")]
		void DialogDidCancel (NSUrl url);

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface FBDialogDelegate {

		//@optional- (void)dialogDidComplete:(FBDialog *)dialog;
		[Abstract, Export ("dialogDidComplete:")]
		void DialogDidComplete (FBDialog dialog);

		//- (void)dialogCompleteWithUrl:(NSURL *)url;
		[Abstract, Export ("dialogCompleteWithUrl:")]
		void DialogCompleteWithUrl (NSUrl url);

		//- (void)dialogDidNotCompleteWithUrl:(NSURL *)url;
		[Abstract, Export ("dialogDidNotCompleteWithUrl:")]
		void DialogDidNotCompleteWithUrl (NSUrl url);

		//- (void)dialogDidNotComplete:(FBDialog *)dialog;
		[Abstract, Export ("dialogDidNotComplete:")]
		void DialogDidNotComplete (FBDialog dialog);

		//- (void)dialog:(FBDialog*)dialog didFailWithError:(NSError *)error;
		[Abstract, Export ("dialog:didFailWithError:")]
		void Dialog (FBDialog dialog, NSError error);

		//- (BOOL)dialog:(FBDialog*)dialog shouldOpenURLInExternalBrowser:(NSURL *)url;
		[Abstract, Export ("dialog:shouldOpenURLInExternalBrowser:")]
		bool Dialog (FBDialog dialog, NSUrl url);

	}

	[BaseType (typeof (FBDialog))]
	interface FBLoginDialog {

		//-(id) initWithURL:(NSString *) loginURL loginParams:(NSMutableDictionary *) params delegate:(id <FBLoginDialogDelegate>) delegate;
		[Export ("initWithURL:loginParams:delegate:")]
		IntPtr Constructor (string loginURL, NSDictionary parms, FBLoginDialogDelegate fbLoginDialogDelegate);

	}
	[Model]

	[BaseType (typeof (NSObject))]
	interface FBLoginDialogDelegate {

		//- (void)fbDialogLogin:(NSString*)token expirationDate:(NSDate*)expirationDate;
		[Abstract, Export ("fbDialogLogin:expirationDate:")]
		void FbDialogLogin (string token, NSDate expirationDate);

		//- (void)fbDialogNotLogin:(BOOL)cancelled;
		[Abstract, Export ("fbDialogNotLogin:")]
		void FbDialogNotLogin (bool cancelled);

	}
}
