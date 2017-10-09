using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.NativeLogin.Facebook.Managers;

namespace Xamarin.Forms.NativeLogin.Facebook.Controls
{
    public class FacebookLoginButton : Button
    {
		public event EventHandler<FacebookLoginEventArgs> LoginSuccess;
		public event EventHandler<ExceptionEventArgs> LoginError;
		public event EventHandler<EventArgs> LoginCancel;

        public string[] Permissions { get; set; }
        public FacebookLoginBehavior Behavior { get; set; } 

        public FacebookLoginButton()
		{
            //set background color to facebook
			BackgroundColor = Color.FromHex("#3B5998");
            Text = "Login with facebook";
			TextColor = Color.White;
		}

		public void FacebookLoginSuccess(string userId, string token, ICollection<string> loginResultRecentlyDeniedPermissions, ICollection<string> loginResultRecentlyGrantedPermissions)
		{
			LoginSuccess?.Invoke(this, new FacebookLoginEventArgs(token, userId));
		}

		public void FacebookLoginError(Exception error)
		{
			LoginError?.Invoke(this, new ExceptionEventArgs(error));
		}

		public void FacebookLoginCancel()
		{
			LoginCancel?.Invoke(this, EventArgs.Empty);
		}

        public void Logout()
        {
            FacebookManager.Logout();
        }
	}

    public enum FacebookLoginBehavior 
    {
        Browser,
        Native,
    }

	public class ExceptionEventArgs
	{
		public Exception Exception { get; set; }

		public ExceptionEventArgs(Exception exception)
		{
			Exception = exception;
		}
	}

	public class FacebookLoginEventArgs : EventArgs
	{
		public string AccessToken { get; set; }
		public string UserId { get; set; }

		public FacebookLoginEventArgs(string accessToken, string userId)
		{
			AccessToken = accessToken;
			UserId = userId;
		}
	}
}

