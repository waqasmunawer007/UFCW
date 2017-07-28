using System;
using System.Collections.Generic;
using UFCW.Services;
using UFCW.ViewModels.Claims;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Claim
{
    public partial class ClaimDetailPage : ContentPage
    {
      
        public ClaimDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

		void EOBButton_Clicked(object sender, System.EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Artina Button Clikced...");
			ClaimDetail detail = (ClaimDetail)BindingContext;
			EOBPage pageEOB = new EOBPage(detail);
			Navigation.PushAsync(pageEOB);
		}
    }
}
