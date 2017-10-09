using Xamarin.Forms;
using Xamarin.Forms.NativeLogin.Facebook.Managers;

namespace Xamarin.Forms.NativeLogin.Facebook
{
    public partial class Xamarin_Forms_NativeLogin_FacebookPage : ContentPage
    {
        async void Handle_LoginSuccess(object sender, Xamarin.Forms.NativeLogin.Facebook.Controls.FacebookLoginEventArgs e)
        {
            await DisplayAlert("Success!", "Login Successfull!", "Whoo!");
        }

        async void Handle_LoginError(object sender, Xamarin.Forms.NativeLogin.Facebook.Controls.ExceptionEventArgs e)
        {
            
            await DisplayAlert("Errored", "Login Errored Out With Code: " + e.Exception, "Hummm");
        }

        async void Handle_LoginCancel(object sender, System.EventArgs e)
        {
            await DisplayAlert("Canceled", "Login Cancled", "Damn");

        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
            FacebookManager.Logout();
		}


		public Xamarin_Forms_NativeLogin_FacebookPage()
        {
            InitializeComponent();
        }
    }
}
