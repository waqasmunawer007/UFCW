using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Pension;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class RetireeDetailPage : ContentPage
    {
        RetireeViewModel retireeVM;
        public RetireeDetailPage()
        {
            InitializeComponent();
            retireeVM = new RetireeViewModel();
            //BindingContext = App.retiree.Personal_Information;
            BindingContext = retireeVM.Retiree.Personal_Information;
            FetchRetiree();
        }

        /// <summary>
        /// Fetchs the Retiree from the server and updates View with data
        /// </summary>
        public async void FetchRetiree()
        {
            retireeVM.IsBusy = true;
            Retiree retiree = await retireeVM.FetchRetiree();
            if (retiree != null)
            {
                //UpdatePage(retiree);
            }
            else
            {
                await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
            }
            retireeVM.IsBusy = false;
        }

        //private void UpdatePage(Benifits[] data)
        //{
        //    foreach (Benifits benifit in data)
        //    {
        //        retireeVM.BenifitsList.Add(benifit);
        //    }
        //}
    }
}
