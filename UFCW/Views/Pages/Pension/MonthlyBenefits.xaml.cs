using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class MonthlyBenefits : ContentPage
    {
        public MonthlyBenefits()
        {
            InitializeComponent();
            BindingContext = App.retiree.Monthly_Benefits;
        }
    }
}
