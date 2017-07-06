using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW
{
	public partial class EligibilityReportPage : ContentPage
	{
        EligibilityReportViewModel viewModel;
		public EligibilityReportPage()
		{
			InitializeComponent();
            viewModel = new EligibilityReportViewModel(Navigation);
            BindingContext = viewModel;
			ReportList.ItemsSource = viewModel.EligibilityReportData;
			ReportList.ItemAppearing += (sender, e) =>
			 {
				 int itemsCount = viewModel.EligibilityReportData.Count;
				 if (viewModel.IsLoading || itemsCount == 0)
					 return;
                Eligibilty lastClaimCellItem = e.Item as Eligibilty;
				 //hit bottom!
                if (lastClaimCellItem.ELIGIBILITY_ID == viewModel.EligibilityReportData[itemsCount - 1].ELIGIBILITY_ID)
				 {
					 viewModel.LoadMore();
				 }
			 };
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			GetEligibilityReport();
			GoogleAnalytics.Current.Tracker.SendView("Eligibility Report Page");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
			viewModel.ResetData();
        }

		public async void GetEligibilityReport()
		{
            viewModel.ResetData();
			viewModel.IsBusy = true;
            await viewModel.FetchEligibilityReport();
			viewModel.IsBusy = false;
		}
       
    }
}
