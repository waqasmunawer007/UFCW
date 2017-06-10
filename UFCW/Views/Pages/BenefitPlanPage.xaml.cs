using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public async void FetchBenifits()
		{
            benifitsVM.IsBusy = true;
            Benifits[] banifits = await benifitsVM.FetchBenifits();
            UpdatePage(banifits);
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
