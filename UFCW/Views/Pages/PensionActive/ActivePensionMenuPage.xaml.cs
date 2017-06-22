using System;
using System.Collections.Generic;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class ActivePensionMenuPage : ContentPage
    {
        ActivePensionMenuVM activePensionMenuVM;
		public ActivePensionMenuPage()
		{
			InitializeComponent();
			activePensionMenuVM = new ActivePensionMenuVM();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = activePensionMenuVM;
		}
    }
}
