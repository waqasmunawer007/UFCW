using System;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.User;
using UFCW.Views.Navigation.Test;
using UFCW.Views.Pages.Eligibility;
using UFCW.Views.Pages.Pension;
using UFCW.Views.Pages.PensionActive;
using Xamarin.Forms;

namespace UFCW
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			InitializeComponent();
			// Empty pages are initially set to get optimal launch experience
			Master = new ContentPage { Title = "Grial" };
			Detail = NavigationPageHelper.Create(new ContentPage());
		}

		public async void OnSettingsTapped(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			SampleCoordinator.SampleSelected += SampleCoordinator_SampleSelected;
			await Task.Delay(500).ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			SampleCoordinator.SampleSelected -= SampleCoordinator_SampleSelected;
		}

		private void InitializeMasterDetail()
		{
			Master = new MainMenuPage(new NavigationService(Navigation, LaunchSampleInDetail));
            Page defaultPage = new EligibilityMenuPage();

            if (Settings.PensionEnrolled)
            {
                if (Settings.RetireeOrActive.Equals(AppConstants.STRING_RETIRE))
                {
                    defaultPage = new PensionMenuPage();
                }
                else
                {
                    defaultPage = new ActivePensionMenuPage();
                }
            }

            Detail = NavigationPageHelper.Create(defaultPage);
		}

		private void LaunchSampleInDetail(Page page, bool animated)
		{
			// CustomNavBarPage must be handled differently because XF seems not to be considering the
			// "NavigationPage.SetHasNavigationBar(this, false);" when you add the page as the 
			// root of the NavigationPage, when you are working in Android.
			if (page is CustomNavBarPage)
			{
				var navigationPage = NavigationPageHelper.Create(new ContentPage());
				Detail = navigationPage;
				navigationPage.PushAsync(page, false);
			}
			else
			{
				Detail = NavigationPageHelper.Create(page);
			}
			IsPresented = false;
		}

		private void SampleCoordinator_SampleSelected(object sender, SampleEventArgs e)
		{
			if (e.Sample.PageType == typeof(RootPage))
			{
				IsPresented = true;
			}
		}
	}
}