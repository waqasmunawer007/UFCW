using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class My_Benifits : ContentPage
    {
        public My_Benifits()
        {
            InitializeComponent();
            BindingContext = App.retiree.My_Benefits;
        }
    }
}
