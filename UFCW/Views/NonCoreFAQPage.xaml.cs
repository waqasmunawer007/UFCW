using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;
using UFCW.Services;
using Xamarin.CustomControls;

namespace UFCW.Views
{
    public partial class NonCoreFAQPage : ContentPage
    {
        NonCoreFAQViewModel viewModel;
        public bool ifPublicFAQRequest;
		StackLayout mainStackLayout;
		AccordionView mainAccordianView;
		ActivityIndicator progressIndicator;

        public NonCoreFAQPage()
        {
            InitializeComponent();
			viewModel = new NonCoreFAQViewModel();
			BindingContext = viewModel;
           
        }

        protected async override void OnAppearing()
		{
			base.OnAppearing();
			SetMainLayout(); //Set Main Content layout
			GoogleAnalytics.Current.Tracker.SendView("NonCore FAQ Page");
			if (ifPublicFAQRequest)
			{
                await viewModel.FetchPublicFAQ();
				ShowExpandableData();
			}
			else
			{
                await viewModel.FetchAuthFAQ();
				ShowExpandableData();
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Content = null;
            viewModel.FAQList.Clear();
		}

		private void SetMainLayout()
		{
			progressIndicator = new ActivityIndicator()
			{
				IsVisible = false,
				IsRunning = false,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			mainAccordianView = new AccordionView()
			{
				Spacing = 0,
				KeepOnlyOneItemOpen = false,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			mainStackLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { progressIndicator, mainAccordianView }
			};
			Content = mainStackLayout;
			progressIndicator.IsVisible = true;
			progressIndicator.IsRunning = true;
		}

		private void ShowExpandableData()
		{

            foreach (FAQ faq in viewModel.FAQList)
			{
				//browser shows news html string
				var browser = new WebView()
				{
					HeightRequest = 100,
					HorizontalOptions = LayoutOptions.FillAndExpand,

				};
				var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = faq.Answer;
				browser.Source = htmlSource;

				StackLayout ItemContentStackLayuot = new StackLayout()
				{
					Padding = new Thickness(5, 0, 15, 15),
					BackgroundColor = Color.White,
					Orientation = StackOrientation.Vertical,
				};
				ItemContentStackLayuot.Children.Add(browser); //add browser into a stack layout


				AccordionItemView accordianItemView = new AccordionItemView()
				{
					ActiveTextColor = Color.Accent,
					Padding = new Thickness(0, 0, 0, 5),
					TextColor = Color.White,
					ButtonBackgroundColor = (Color)Application.Current.Resources["BackgroundColor"],
					ButtonActiveBackgroundColor = (Color)Application.Current.Resources["BackgroundColor"],
					TextPosition = TextPosition.Left,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					ItemContent = new StackLayout()
					{
						Padding = new Thickness(0.5, 0, 0.5, 0.5),
						BackgroundColor = Color.Black,
						Children = { ItemContentStackLayuot }
					}

				};
                accordianItemView.Text = faq.Question;
				mainAccordianView.Children.Add(accordianItemView);

				progressIndicator.IsVisible = false;
				progressIndicator.IsRunning = false;
			}
		}
    }
}
