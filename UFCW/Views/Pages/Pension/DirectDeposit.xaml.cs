using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class DirectDeposit : ContentPage
    {
        public DirectDeposit()
        {
            InitializeComponent();
            BindingContext = App.retiree.Direct_Deposit;
        }
    }
}
