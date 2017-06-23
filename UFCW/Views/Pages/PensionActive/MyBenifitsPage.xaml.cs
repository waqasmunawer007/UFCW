using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class MyBenifitsPage : ContentPage
    {
        MyBenifitsVM benifitsVM;
        public MyBenifitsPage()
        {
            InitializeComponent();
            benifitsVM = new MyBenifitsVM();
            FetchBenifits();
		}

		async Task FetchBenifits()
		{
            MyBenifits myBenefits =  await benifitsVM.FetchBenifits();
            if(myBenefits != null)
            {
				BenefitsLabel.Text = "Based on our records you have accrued approximately " + benifitsVM.Benifits.CreditedServiceYears + " years of service credit " +
				  "under the UFCW Consolidated Pension Fund." +
				  "\n\nAt present, the Normal Retirement estimated monthly benefit " +
					  "amount is " + benifitsVM.Benifits.EstimatedMonthlyBenefit + ".\n\nYou are not eligible for Early Retirement because you have less than " + benifitsVM.Benifits.EligibilityServiceYears + " years of Eligibility Service.\n\nThese " +
				  "estimates are provided for information only. Your right to any benefit and " +
				  "the amount of your benefit will depend on the actual credited service verified at the time you apply for retirement and the " +
				  "provisions of the plan document. If you need any additional information or if you have any questions, please contact the Fund Office.";
			}
            else
            {
                await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
          
		}
    }
}
