using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Forms.NativeLogin.Facebook.Managers;
using Xamarin.Facebook.Login;

namespace Xamarin.Forms.NativeLogin.Facebook.Droid
{
    [Activity(Label = "Xamarin.Forms.NativeLogin.Facebook.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static ICallbackManager CallbackManager = CallbackManagerFactory.Create();

        protected override void OnCreate(Bundle bundle)
        {
            FacebookManager.OnLogout += (sender, e) => LoginManager.Instance.LogOut();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
			base.OnActivityResult(requestCode, resultCode, data);
		}
    }
}
