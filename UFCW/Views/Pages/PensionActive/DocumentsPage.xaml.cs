using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class DocumentsPage : ContentPage
    {
        DocumentsVM documentsVM;
		public DocumentsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			documentsVM = new DocumentsVM();
			BindingContext = documentsVM;
            DocumentsList.ItemsSource = documentsVM.documentsList;
			FetchDocuments();
			DocumentsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
		}

		/// <summary>
        /// Fetchs the documents.
        /// </summary>
		public async void FetchDocuments()
		{
			documentsVM.IsBusy = true;
            PlanDocument[] documents = await documentsVM.FetchDocuments();
			if (documents != null)
			{
				UpdatePage(documents);
			}
			else
			{
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			documentsVM.IsBusy = false;
		}

		/// <summary>
        /// Updates the page.
        /// </summary>
        /// <param name="data">Data.</param>
		private void UpdatePage(PlanDocument[] data)
		{
            foreach (PlanDocument document in data)
			{
                documentsVM.documentsList.Add(document);
			}
		}

        public void LinkClicked(object sender, System.EventArgs e)
        {
			string url = ((Button)sender).Text;
			Device.OpenUri(new System.Uri(url));
        }
	}
}
