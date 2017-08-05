using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.CustomControls;
using Xamarin.Forms;

namespace UFCW.Views.Pages
{
    public partial class NewsLetterPage : ContentPage
    {
        NewsLetterViewModel viewModel;
        public bool ifPublicNewsLetterRequest;
        StackLayout mainStackLayout;
        AccordionView mainAccordianView;
        ActivityIndicator progressIndicator;
        public NewsLetterPage()
        {
            InitializeComponent();
            viewModel = new NewsLetterViewModel();
			BindingContext = viewModel;
        }
        protected async  override void OnAppearing()
        {
            base.OnAppearing();
            SetMainLayout(); //Set Main Content layout
          
			if (ifPublicNewsLetterRequest)
			{
                await viewModel.FetchPublicNewsLetter();
                ShowExpandableData();
			}
			else
			{
                await viewModel.FetchAuthNewsLetter();
				ShowExpandableData();
			}
           
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
                Children = { progressIndicator,mainAccordianView }
			};
			Content = mainStackLayout;
			progressIndicator.IsVisible = true;
			progressIndicator.IsRunning = true;
        }
        private void ShowExpandableData()
        {
          
            foreach (NewsLetter newsLetter in viewModel.NewsLetterList)
            {
                //browser shows news html string
				var browser = new WebView()
				{
					HeightRequest = 100,
					HorizontalOptions = LayoutOptions.FillAndExpand,

				};
				var htmlSource = new HtmlWebViewSource();
				htmlSource.Html = newsLetter.Template; 
				browser.Source = htmlSource;

				StackLayout ItemContentStackLayuot = new StackLayout()
				{
					Padding = new Thickness(5,0,15,15),
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
				accordianItemView.Text = newsLetter.Title;
				mainAccordianView.Children.Add(accordianItemView);

				progressIndicator.IsVisible = false;
				progressIndicator.IsRunning = false;
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Content = null;
            viewModel.NewsLetterList.Clear();
        }
    }
}
