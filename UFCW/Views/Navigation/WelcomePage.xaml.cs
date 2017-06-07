using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace UFCW
{
	public partial class WelcomePage : ContentPage
	{
		private bool isPageLoaded = true;

		public WelcomePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing()
		{
			AnimationView.Play();

			Device.StartTimer(TimeSpan.FromMilliseconds(2500), () =>
			{
				if (isPageLoaded)
				{
					AnimationView.Play();
				}

				return isPageLoaded;
			});

		}

		protected override void OnDisappearing()
		{
			isPageLoaded = false;
		}

		public async void OnWalkthroughButtonTapped(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new RootPage());
		}

		public async void OnBrowseSamplesButtonTapped(object sender, EventArgs e)
		{
			try
			{
				isPageLoaded = false;
				await Navigation.PopModalAsync();
			}
			catch (ArgumentOutOfRangeException) { }
		}

		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			try
			{
				isPageLoaded = false;
				await Navigation.PopModalAsync();
			}
			catch (ArgumentOutOfRangeException) { }
		}
	}
}