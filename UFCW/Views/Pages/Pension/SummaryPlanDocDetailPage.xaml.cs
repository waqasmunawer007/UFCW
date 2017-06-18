using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class SummaryPlanDocDetailPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            string url = ((Button)sender).Text;
            Debug.WriteLine("Link to click: \n" + url);
            Device.OpenUri(new System.Uri(url));
        }

        public SummaryPlanDocDetailPage()
        {
            InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
