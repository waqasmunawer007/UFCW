using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Pension;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class SummaryPlanDocPage : ContentPage
    {
        SummaryPlanDocViewModel summaryPlanDocVM;
        public SummaryPlanDocPage()
        {
            InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
            summaryPlanDocVM = new SummaryPlanDocViewModel();
			BindingContext = summaryPlanDocVM;
            SummaryPlanDocsList.ItemsSource = summaryPlanDocVM.SummaryPlanDocsList;
			FetchSummaryPlanDocs();
        }

		/// <summary>
		/// Fetchs the Summary Plan Docs from the server.
		/// </summary>
		public async void FetchSummaryPlanDocs()
		{
			summaryPlanDocVM.IsBusy = true;
            SummaryPlanDoc[] list = await summaryPlanDocVM.FetchSummaryPlanDocs();
            if (list != null)
			{
                UpdatePage(list); 
			}
			else
			{
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			summaryPlanDocVM.IsBusy = false;
		}

		/// <summary>
		/// Updates the listview 
		/// </summary>
		/// <param name="data">Data.</param>
		private void UpdatePage(SummaryPlanDoc[] data)
		{
            foreach (SummaryPlanDoc summaryDoc in data)
			{
                summaryPlanDocVM.SummaryPlanDocsList.Add(summaryDoc);
			}
		}

		/// <summary>
		/// Handles the Summary Doc tapped event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var selectedsummaryDoc = ((ListView)sender).SelectedItem;
			SummaryPlanDoc summaryDoc = (SummaryPlanDoc)selectedsummaryDoc;
            SummaryPlanDocDetailPage summaryPlanDetailPage = new SummaryPlanDocDetailPage();
			summaryPlanDetailPage.BindingContext = summaryDoc;
			await Navigation.PushAsync(summaryPlanDetailPage);
			((ListView)sender).SelectedItem = null;
		}
    }
}
