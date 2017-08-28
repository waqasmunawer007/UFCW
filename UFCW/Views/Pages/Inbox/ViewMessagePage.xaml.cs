using System;
using System.Collections.Generic;
using UFCW.Services.Models.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ViewMessagePage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ComposeMessagePage());
        }

        public ViewMessagePage(Message message)
        {
            InitializeComponent();
            BindingContext = message;
            Title = message.From;
        }
    }
}
