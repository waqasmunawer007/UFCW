using System;
using System.Collections.Generic;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Eligibility
{
    public partial class EligibilityDetailPage : ContentPage
    {
        EligibilityDetailViewModel viewModel;
        public Eligibilty SelectedEligibility;
        public EligibilityDetailPage()
        {
            InitializeComponent();
            viewModel = new EligibilityDetailViewModel(SelectedEligibility.ELIGIBILITY_ID);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetEiligibilityDetail();
        }
        private void GetEiligibilityDetail()
        {
            viewModel.FetchEligibilityDetail();
        }
    }
}
