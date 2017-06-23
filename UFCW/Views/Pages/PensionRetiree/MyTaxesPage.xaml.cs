using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class MyTaxesPage : ContentPage
    {
        public MyTaxesPage()
        {
            InitializeComponent();
            BindingContext = App.retiree.MyTaxes;
        }
    }
}
