using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class MyTaxes : ContentPage
    {
        public MyTaxes()
        {
            InitializeComponent();
            BindingContext = App.retiree.MyTaxes;
        }
    }
}
