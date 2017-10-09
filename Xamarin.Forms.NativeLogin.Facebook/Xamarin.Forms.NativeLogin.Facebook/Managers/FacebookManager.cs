using System;
namespace Xamarin.Forms.NativeLogin.Facebook.Managers
{
    public static class FacebookManager
    {
        private static event EventHandler OnLogout;

        public static void Logout()
        {
            OnLogout?.Invoke(null, EventArgs.Empty);
        }

        public static void RegisterLogout(Action action)
        {
            OnLogout += (sender, args) => action.Invoke();
        }
    }
}
