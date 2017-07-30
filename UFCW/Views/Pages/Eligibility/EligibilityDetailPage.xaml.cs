using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Eligibility
{
    public partial class EligibilityDetailPage : ContentPage
    {
        EligibilityDetailViewModel viewModel;
        private Eligibilty selectedEligibility;
        public EligibilityDetailPage(Eligibilty eligibilityItem)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			selectedEligibility = eligibilityItem;
            viewModel = new EligibilityDetailViewModel();
           
           

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetEiligibilityDetail();
        }
        private async Task GetEiligibilityDetail()
        {
            await viewModel.FetchEligibilityDetail(selectedEligibility.ELIGIBILITY_ID);
            viewModel.EligibilityObj = selectedEligibility;
			BindingContext = viewModel;
           
        }
    }
}
