using System;
using System.Collections.Generic;
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
			dependentsVM = new DependentsViewModel();
			BindingContext = dependentsVM;
            DependentsList.ItemsSource = dependentsVM.dependentsList;
			FetchDependents();
		}

        public async void FetchDependents()
        {
			dependentsVM.IsBusy = true;
            Dependant[] banifits = await dependentsVM.FetchDependents();
			UpdatePage(banifits);
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
		}
	}
}
