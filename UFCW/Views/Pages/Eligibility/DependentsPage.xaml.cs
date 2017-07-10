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
		}

		/// <summary>
		/// Fetchs the dependents list from server
		/// </summary>
        public async void FetchDependents()
        {
			dependentsVM.IsBusy = true;
            Dependant[] dependents = await dependentsVM.FetchDependents();
            if (dependents != null && dependents.Length > 0)
			{
                DependentsList.IsVisible = true;
                NoDataLabel.IsVisible = false;
				UpdatePage(dependents);
			}
			else
			{
				DependentsList.IsVisible = false;
				NoDataLabel.IsVisible = true;
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

		protected override void OnAppearing()
		{
			FetchDependents();
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			dependentsVM.dependentsList.Clear();
            NoDataLabel.IsVisible = false;
            DependentsList.IsVisible = false;
		}
	}
}
