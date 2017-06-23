using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
using UFCW.Services.Models.User;
using UFCW.ViewModels;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginVm;
        public LoginPage()
        {
            InitializeComponent();
            loginVm = new LoginViewModel();
            retireeVM = new RetireeViewModel();
            BindingContext = loginVm;
            NavigationPage.SetHasNavigationBar(this, false);
		}

		      async Task LoginClicked()
		{
		if(!String.IsNullOrEmpty(loginVm.Email) && !String.IsNullOrEmpty(loginVm.Password))
		{
		loginVm.ShowError = false;
		            loginVm.IsBusy = true;
		//LoginResponse response = await loginVm.LogiUser(loginVm.Email, loginVm.Password);
		LoginResponse response = await loginVm.LogiUser("UfcwRetiree@sinettechnologies.com", "P@ssw0rd");
		loginVm.IsBusy = false;
		if (String.IsNullOrEmpty(response.ErrorText) && String.IsNullOrEmpty(response.ErrorDetails))
		{
			loginVm.user = response.Profile;
			User user = response.Profile;
			App.user = user; //Todo temp code
			Settings.UserSSN = user.SSN;
			Settings.UserEmail = user.Email;
			Settings.UserToken = response.Token;
		    await Navigation.PushModalAsync(new RootPage());
			//FetchRetiree();
		}
		else
		{
			await this.DisplayAlert(AppConstants.LOGIN_FAILED,response.ErrorDetails,null, AppConstants.DIALOG_OK_OPTION);
		}
    }
    else
    {
	loginVm.ShowError = true;
   }
}


		//async Task LoginClicked()
		//{
		//	if (!String.IsNullOrEmpty(loginVm.Email) && !String.IsNullOrEmpty(loginVm.Password))
		//	{
		//		loginVm.ShowError = false;
		//		loginVm.IsBusy = true;
		//		LoginResponse response = await loginVm.LogiUser(loginVm.Email, loginVm.Password);
		//		//LoginResponse response = await loginVm.LogiUser("Sam@paysolar.com", "P@ssw0rd");
  //              //LoginResponse response = await loginVm.LogiUser("ufcwRetiree@sinettechnologies.com", "P@ssw0rd");
		//		loginVm.IsBusy = false;
		//		if (String.IsNullOrEmpty(response.ErrorText) && String.IsNullOrEmpty(response.ErrorDetails))
		//		{
		//			loginVm.user = response.Profile;
		//			User user = response.Profile;
		//			App.user = user; //Todo need to store in local storage
		//			// store ssn,email & token in key-pair formats locally.
		//			Settings.UserSSN = user.SSN;
		//			Settings.UserEmail = user.Email;
		//			Settings.UserToken = response.Token;
					
		//			await Navigation.PushModalAsync(new RootPage());
  //                  FetchRetiree();
		//		}
		//		else
		//		{
		//			await this.DisplayAlert(AppConstants.LOGIN_FAILED, response.ErrorDetails, null, AppConstants.DIALOG_OK_OPTION);
		//		}
		//	}
		//	else
		//	{
		//		loginVm.ShowError = true;
		//	}
		//}

		///// <summary>
		///// Fetchs the Retiree from the server and updates View with data
		///// </summary>
		//public async void FetchRetiree()
		//{
  //          loginVm.IsBusy = true;
		//	Retiree retiree = await retireeVM.FetchRetiree();
		//	if (retiree != null)
		//	{
  //              //UpdatePage(retiree);
  //              App.retiree = retiree;
  //              Debug.WriteLine("SSN: "+App.retiree.SurvivorsData.SurvivorGender);
		//	}
		//	else
		//	{
		//		await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
		//	}
		//	loginVm.IsBusy = false;
		//}

    }
}
