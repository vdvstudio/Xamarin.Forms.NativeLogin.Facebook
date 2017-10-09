using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.NativeLogin.Facebook.Controls;

namespace Xamarin.Forms.NativeLogin.Facebook
{
    public partial class DoFacebookStuff : ContentPage
    {
        public FacebookLoginEventArgs EventArgs { get; set; }
        public DoFacebookStuff(FacebookLoginEventArgs eventArgs)
        {
            InitializeComponent();
            Appearing += DoFacebookStuff_Appearing;
        }


        async void DoFacebookStuff_Appearing(object sender, System.EventArgs e)
        {
            
        }
    }
}
