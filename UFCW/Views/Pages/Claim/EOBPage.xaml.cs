using System;
using System.Collections.Generic;
using UFCW.Services;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Claim
{
    public partial class EOBPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EOBServiceProvidersPage());
        }

        public EOBPage(ClaimDetail claimDetail)
        {
            InitializeComponent();
            BindingContext = claimDetail;
            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
