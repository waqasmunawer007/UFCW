using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Services.Models.Eligibility.Benifits;
using UFCW.ViewModels;
using Xamarin.Forms;

namespace UFCW
{
	public partial class BenefitPlanPage : ContentPage
	{
        BenifitsViewModel benifitsVM;

		public BenefitPlanPage()
		{
		    InitializeComponent();
            benifitsVM = new BenifitsViewModel();
            BindingContext = benifitsVM;
            BenifitsList.ItemsSource = benifitsVM.BenifitsList;
            FetchBenifits();
		}

		/// <summary>
		/// Fetchs the benifits list from the server and updates ListView with data
		/// </summary>
        public async void FetchBenifits()
		{
            benifitsVM.IsBusy = true;
            Benifits[] banifits = await benifitsVM.FetchBenifits();
			if (banifits != null)
			{
				UpdatePage(banifits);
			}
			else
			{ 
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
            benifitsVM.IsBusy = false;
		}

		private void UpdatePage(Benifits[] data)
		{
            foreach (Benifits benifit in data)
			{
                benifitsVM.BenifitsList.Add(benifit);
			}
		}
	}
}
