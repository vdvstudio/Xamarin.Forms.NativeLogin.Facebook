using System;
using Java.Interop;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Forms;
using Xamarin.Forms.NativeLogin.Facebook.Controls;
using Xamarin.Forms.NativeLogin.Facebook.Droid.Renderers;
using Xamarin.Forms.NativeLogin.Facebook.Managers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(CustomFacebookButtonRenderer))]
namespace Xamarin.Forms.NativeLogin.Facebook.Droid.Renderers
{
	public class CustomFacebookButtonRenderer : ButtonRenderer
	{
		private readonly LoginButton _loginButton;
		private FacebookLoginButton _facebookLoginButton;
		private FacebookCallback<LoginResult> LoginCallback { get; set; }

		public CustomFacebookButtonRenderer()
		{
            _loginButton = new LoginButton(Context)
			{
				LoginBehavior = LoginBehavior.NativeWithFallback
			};

			LoginCallback = new FacebookCallback<LoginResult>();
			LoginCallback.HandleSuccess = loginResult =>
			{
				_facebookLoginButton.FacebookLoginSuccess(loginResult.AccessToken.UserId, loginResult.AccessToken.Token,
					loginResult.RecentlyDeniedPermissions, loginResult.RecentlyGrantedPermissions);
			};
			LoginCallback.HandleCancel = () => _facebookLoginButton.FacebookLoginCancel();
			LoginCallback.HandleError = (e) => _facebookLoginButton.FacebookLoginError(e);

			LoginManager.Instance.RegisterCallback(MainActivity.CallbackManager, LoginCallback);
		}


		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			if (e.NewElement is FacebookLoginButton)
			{
				_facebookLoginButton = e.NewElement as FacebookLoginButton;
				e.NewElement.Clicked += Control_Click;
			}
			base.OnElementChanged(e);

		}

		private void Control_Click(object sender, System.EventArgs e)
		{
			_loginButton.PerformClick();
		}

	}

    public class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
	{
		public Action HandleCancel { get; set; }
		public Action<FacebookException> HandleError { get; set; }
		public Action<TResult> HandleSuccess { get; set; }

		public void OnCancel()
		{
			HandleCancel?.Invoke();
		}

		public void OnError(FacebookException error)
		{
			HandleError?.Invoke(error);
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			HandleSuccess?.Invoke(result.JavaCast<TResult>());
		}
	}
}