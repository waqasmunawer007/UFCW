using System;
using System.Collections.Generic;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
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
            Dependants[] banifits = await dependentsVM.FetchDependents();
			UpdatePage(banifits);
			dependentsVM.IsBusy = false;
		}

		private void UpdatePage(Dependants[] data)
		{
			foreach (Dependants checkDetail in data)
			{
                dependentsVM.dependentsList.Add(checkDetail);
			}
		}
	}
}
