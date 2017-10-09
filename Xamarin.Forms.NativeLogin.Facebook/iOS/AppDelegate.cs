using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using UIKit;
using Xamarin.Forms.NativeLogin.Facebook.Managers;

namespace Xamarin.Forms.NativeLogin.Facebook.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		private const string _appId = "530053500680672";
		private const string _appName = "Xamarin.Forms Native Login";

        public static LoginManager LoginManager { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Profile.EnableUpdatesOnAccessTokenChange(true);
			Settings.AppID = _appId;
			Settings.DisplayName = _appName;

			LoginManager = new LoginManager();
            FacebookManager.RegisterLogout(() => LoginManager.LogOut());

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
		}
    }
}
