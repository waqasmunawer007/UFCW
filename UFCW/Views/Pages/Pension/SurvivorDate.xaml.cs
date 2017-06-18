using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class SurvivorDate : ContentPage
    {
        public SurvivorDate()
        {
            InitializeComponent();
            BindingContext = App.retiree.SurvivorsData;
        }
    }
}
