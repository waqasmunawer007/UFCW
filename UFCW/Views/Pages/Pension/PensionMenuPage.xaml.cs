using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Pension;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class PensionMenuPage : ContentPage
    {
        PensionMenuVM pensionMenuVM;
        public PensionMenuPage()
        {
            InitializeComponent();
			pensionMenuVM = new PensionMenuVM();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = pensionMenuVM;
			FetchRetiree();
        }

		/// <summary>
		/// Fetchs the Retiree from the server and updates View with data
		/// </summary>
		public async void FetchRetiree()
		{
			pensionMenuVM.IsBusy = true;
			Retiree retiree = await pensionMenuVM.FetchRetiree();
			if (retiree != null)
			{
				App.retiree = retiree;

			}
			else
			{
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			pensionMenuVM.IsBusy = false;
		}

    }
}
