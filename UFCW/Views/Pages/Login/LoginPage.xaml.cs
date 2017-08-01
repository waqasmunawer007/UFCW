using Plugin.GoogleAnalytics;
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
        PensionMenuVM pensionViewModel;
        public LoginPage()
        {
            InitializeComponent();
            loginVm = new LoginViewModel();
            pensionViewModel = new PensionMenuVM();
            BindingContext = loginVm;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Login Page");
        }
        async Task LoginClicked()
		{
            GoogleAnalytics.Current.Tracker.SendEvent("Button", "Clicked", AppConstants.Login_Event_Message, 1);
            if (!String.IsNullOrEmpty(loginVm.Email) && !String.IsNullOrEmpty(loginVm.Password))
			{
				loginVm.ShowError = false;
				loginVm.IsBusy = true;
				//LoginResponse response = await loginVm.LogiUser(loginVm.Email, loginVm.Password);
				LoginResponse response = await loginVm.LogiUser("UfcwActiveHW@sinettechnologies.com", "P@ssw0rd"); //for Eligibilty & Active pension
                //LoginResponse response = await loginVm.LogiUser("ufcwRetiree@sinettechnologies.com", "P@ssw0rd");
                //LoginResponse response = await loginVm.LogiUser("UfcwActive@sinettechnologies.com", "P@ssw0rd");
				if (String.IsNullOrEmpty(response.ErrorText) && String.IsNullOrEmpty(response.ErrorDetails))
				{
					loginVm.user = response.Profile;
					User user = response.Profile;
					App.user = user; //Todo need to store in local storage
					// store ssn,email & token in key-pair formats locally.
					Settings.UserSSN = user.SSN;
					Settings.UserEmail = user.Email;
					Settings.UserToken = response.Token;
                    if(response.InsuranceEnrolled != null && response.InsuranceEnrolled == "True")
                    {
                        Settings.InsuranceEnrolled = true;   
                    }
                    else
                    {
                        Settings.InsuranceEnrolled = false;
					}

                    if (response.PensionEnrolled != null && response.PensionEnrolled == "True")
					{
						Settings.PensionEnrolled = true;
					}
					else
					{
						Settings.PensionEnrolled = false;
					}

                    Settings.RetireeOrActive = response.RetireeOrActive;

                    //TODO Do it on proper place...
                    if (Settings.RetireeOrActive != null && Settings.RetireeOrActive.Equals(AppConstants.STRING_RETIRE))
                    {
                        FetchPensionRetiree(); //Fetch Pension Retiree data
                    }
                    else
                    {
                        loginVm.IsBusy = false;
                        await Navigation.PushModalAsync(new RootPage()); 
                    }
					    
				}
				else
				{
					await this.DisplayAlert(AppConstants.LOGIN_FAILED, response.ErrorDetails, null, AppConstants.DIALOG_OK_OPTION);
				}
			}
			else
			{
				loginVm.ShowError = true;
			}
		}

		/// <summary>
        /// Fetchs the pension retiree.
        /// </summary>
		public async void FetchPensionRetiree()
		{
			
			Retiree retiree = await pensionViewModel.FetchRetiree();
            loginVm.IsBusy = false;
			if (retiree != null)
			{
				App.retiree = retiree;
                await Navigation.PushModalAsync(new RootPage());
			}
			else
			{
				//await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
		}
    }
}
