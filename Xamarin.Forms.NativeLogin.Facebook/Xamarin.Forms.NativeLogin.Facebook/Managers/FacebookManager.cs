using System;
namespace Xamarin.Forms.NativeLogin.Facebook.Managers
{
    public static class FacebookManager
    {
        public static event EventHandler OnLogout;

        public static void Logout()
        {
            OnLogout?.Invoke(null, EventArgs.Empty);
        }
    }
}
