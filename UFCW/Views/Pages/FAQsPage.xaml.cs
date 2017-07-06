using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services;
using Xamarin.Forms;

namespace UFCW
{
	public partial class FAQsPage : ContentPage
	{
		FAQViewModel viewModel;

		public FAQsPage()
		{
			InitializeComponent();
			viewModel = new FAQViewModel();
			BindingContext = viewModel;
			FAQsList.ItemsSource = viewModel.FAQList;
			FetchFAQs();
		}

		/// <summary>
		/// Fetchs the FAQS list from the server and updates ListView with the data
		/// </summary>
		public async void FetchFAQs()
		{
			viewModel.IsBusy = true;
			FAQ[] faqs = await viewModel.GetFAQs();
			if (faqs != null)
			{
				UpdatePage(faqs);
			}
			else
			{
				//todo show this message in center of the screen, if data list is empty
				await this.DisplayAlert("", AppConstants.Empty_Data_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			viewModel.IsBusy = false;
		}
		private void UpdatePage(FAQ[] data)
		{
			foreach (FAQ faq in data)
			{
				viewModel.FAQList.Add(faq);
			}
		}
	}
}
