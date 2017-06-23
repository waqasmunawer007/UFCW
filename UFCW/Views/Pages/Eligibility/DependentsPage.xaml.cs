using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
using UFCW.Views.Pages;
using Xamarin.Forms;

namespace UFCW
{
	public partial class DependentsPage : ContentPage
	{
        DependentsViewModel dependentsVM;

		public DependentsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			dependentsVM = new DependentsViewModel();
			BindingContext = dependentsVM;
            DependentsList.ItemsSource = dependentsVM.dependentsList;
			FetchDependents();
		}

		/// <summary>
		/// Fetchs the dependents list from server
		/// </summary>
        public async void FetchDependents()
        {
			dependentsVM.IsBusy = true;
            Dependant[] banifits = await dependentsVM.FetchDependents();
			if (banifits != null)
			{
				UpdatePage(banifits);
			}
			else
			{
				//todo show this message in center of the screen, if data list is empty
				await this.DisplayAlert("", AppConstants.Empty_Data_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			dependentsVM.IsBusy = false;
		}

		private void UpdatePage(Dependant[] data)
		{
            foreach (Dependant dependantDetail in data)
			{
                dependentsVM.dependentsList.Add(dependantDetail);
			}
		}

		/// <summary>
		/// Handles the Dependant item tapped event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            var selectedDependant = ((ListView)sender).SelectedItem;
            Dependant dependant = (Dependant)selectedDependant;
            DependantsDetailPage dependantsDetailPage = new DependantsDetailPage();
			dependantsDetailPage.BindingContext = dependant;
			await Navigation.PushAsync(dependantsDetailPage);
            ((ListView)sender).SelectedItem = null;
		}
	}
}
