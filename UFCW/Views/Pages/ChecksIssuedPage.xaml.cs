using System;
using System.Collections.Generic;
using UFCW.Services.Models.Eligibility.ChecksIssued;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW
{
	public partial class ChecksIssuedPage : ContentPage
	{
        ChecksIssuedViewModel checksIssuedVM;
		public ChecksIssuedPage()
		{
			InitializeComponent();
			checksIssuedVM = new ChecksIssuedViewModel();
			BindingContext = checksIssuedVM;
			ChecksIssuedList.ItemsSource = checksIssuedVM.checksIssuedList;
			FetchChecksIssued();
		}

        public async void FetchChecksIssued()
        {
			checksIssuedVM.IsBusy = true;
			ChecksIssued[] banifits = await checksIssuedVM.FetchChecksIssued();
			UpdatePage(banifits);
			checksIssuedVM.IsBusy = false;
        }

		private void UpdatePage(ChecksIssued[] data)
		{
			foreach (ChecksIssued checkDetail in data)
			{
                checksIssuedVM.checksIssuedList.Add(checkDetail);
			}
		}
	}
}
