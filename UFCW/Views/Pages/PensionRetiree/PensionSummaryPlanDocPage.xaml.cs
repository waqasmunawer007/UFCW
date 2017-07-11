using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Pension;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class PensionSummaryPlanDocPage : ContentPage
    {
        SummaryPlanDocViewModel summaryPlanDocVM;
        public PensionSummaryPlanDocPage()
        {
            InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
            summaryPlanDocVM = new SummaryPlanDocViewModel();
			BindingContext = summaryPlanDocVM;
            SummaryPlanDocsList.ItemsSource = summaryPlanDocVM.SummaryPlanDocsList;
			SummaryPlanDocsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
        }
        /// <summary>
        /// Fetchs the Summary Plan Docs from the server.
        /// </summary>
        public async void FetchSummaryPlanDocs()
        {
            summaryPlanDocVM.IsBusy = true;
            SummaryPlanDoc[] list = await summaryPlanDocVM.FetchSummaryPlanDocs();
            if (list != null &&  list.Length > 0)
			{
                SummaryPlanDocsList.IsVisible = true;
                NoDataLabel.IsVisible = false;
                UpdatePage(list);
            }
            else
            {
				SummaryPlanDocsList.IsVisible = false;
				NoDataLabel.IsVisible = true;
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
        /// Handle Link clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
		public void LinkClicked(object sender, System.EventArgs e)
		{
			string url = ((Button)sender).Text;
			Device.OpenUri(new System.Uri(url));
		}

		protected override void OnAppearing()
		{
			FetchSummaryPlanDocs();
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			summaryPlanDocVM.SummaryPlanDocsList.Clear();
            NoDataLabel.IsVisible = false;
            SummaryPlanDocsList.IsVisible = false;
		}
    }
}
