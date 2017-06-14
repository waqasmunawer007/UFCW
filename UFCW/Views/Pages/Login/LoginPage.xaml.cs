using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Services.Models.User;
using UFCW.ViewModels;
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
            BindingContext = loginVm;
		}

        async Task LoginClicked()
		{
			if(!String.IsNullOrEmpty(loginVm.Email) && !String.IsNullOrEmpty(loginVm.Password))
			{
				loginVm.ShowError = false;
                loginVm.IsBusy = true;
				LoginResponse response = await loginVm.LogiUser(loginVm.Email, loginVm.Password);
				//LoginResponse response = await loginVm.LogiUser("Sam@paysolar.com", "P@ssw0rd");
				loginVm.IsBusy = false;
				if (String.IsNullOrEmpty(response.ErrorText) && String.IsNullOrEmpty(response.ErrorDetails))
				{
					loginVm.user = response.Profile;
					User user = response.Profile;
					App.user = user; //Todo temp code
                    await Navigation.PushModalAsync(new RootPage());
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

    }
}
