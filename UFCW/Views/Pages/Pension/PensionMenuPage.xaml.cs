using System;
using System.Collections.Generic;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class PensionMenuPage : ContentPage
    {
        PensionMenuVM pensionMenuVM;
        public PensionMenuPage()
        {
            InitializeComponent();
			pensionMenuVM = new PensionMenuVM();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = pensionMenuVM;
        }
    }
}
