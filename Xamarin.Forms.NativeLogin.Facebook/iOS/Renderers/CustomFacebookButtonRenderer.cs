using System;
using System.Linq;
using CoreGraphics;
using Facebook.LoginKit;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.NativeLogin.Facebook.Controls;
using Xamarin.Forms.NativeLogin.Facebook.iOS.Renderers;
using Xamarin.Forms.NativeLogin.Facebook.Managers;
using Xamarin.Forms.Platform.iOS;
[assembly:ExportRenderer(typeof(FacebookLoginButton), typeof(CustomFacebookButtonRenderer))]

namespace Xamarin.Forms.NativeLogin.Facebook.iOS.Renderers
{
    public class CustomFacebookButtonRenderer : ButtonRenderer
    {

        private FacebookLoginButton _facebookLoginButton;

        public CustomFacebookButtonRenderer()
        {
            FacebookManager.OnLogout += facebookLogout;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            if (e.NewElement is FacebookLoginButton)
            {
                _facebookLoginButton = e.NewElement as FacebookLoginButton;
                e.NewElement.Clicked += NewElement_Clicked;
            }
            base.OnElementChanged(e);
        }

        private void NewElement_Clicked(object sender, System.EventArgs e)
        {
            var behaviour = _facebookLoginButton.Behavior;
            var facebookBehaviour = LoginBehavior.Native;
            switch(behaviour)
            {
                case FacebookLoginBehavior.Browser:
                    facebookBehaviour = LoginBehavior.Browser;
                    break;
                case FacebookLoginBehavior.Native:
                    facebookBehaviour = LoginBehavior.Native;
                    break;
            }
            var loginView = new LoginButton(new CGRect(48, 0, 218, 46))
            {
                LoginBehavior = facebookBehaviour,
                ReadPermissions = _facebookLoginButton.Permissions,
            };
            loginView.Completed += (sender1, e1) => {
                Handler(e1.Result, e1.Error);
            };

            loginView.SendActionForControlEvents(UIControlEvent.TouchUpInside);
        }

        void facebookLogout(object sender, EventArgs e)
        {
            AppDelegate.LoginManager.LogOut();
        }

        private void Handler(LoginManagerLoginResult result, NSError error)
        {
            if (error != null)
            {
                _facebookLoginButton.FacebookLoginError(new NSErrorException(error));
                return;
            }
            if (result.IsCancelled)
            {
                _facebookLoginButton.FacebookLoginCancel();
                return;
            }

            if (result.Token != null)
            {
                var token = result.Token;
                _facebookLoginButton.FacebookLoginSuccess(token.UserID, token.TokenString,
                    result.DeclinedPermissions.ToArray<NSString>().Select(x => x.ToString()).ToArray(),
                    result.GrantedPermissions.ToArray<NSString>().Select(x => x.ToString()).ToArray());
            }
        }
    }
}