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
		public RetireeDetailPage()
		{
			InitializeComponent();
			BindingContext = App.retiree.Personal_Information; 
		}
    }
}
