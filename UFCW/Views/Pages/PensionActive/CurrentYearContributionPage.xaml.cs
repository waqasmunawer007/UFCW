using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class CurrentYearContributionPage : ContentPage
    {
        CurrentYearContributionVM contributionVM;
        public CurrentYearContributionPage()
        {
            InitializeComponent();
            contributionVM = new CurrentYearContributionVM();
            FetchCurrentYearContribution();
        }

        async Task  FetchCurrentYearContribution()
        {
            await contributionVM.FetchCurrentYearContribution();
            BindingContext = contributionVM.currentYearContribution;
        }

    }
}
