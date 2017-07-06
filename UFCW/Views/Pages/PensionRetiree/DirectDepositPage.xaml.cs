﻿using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class DirectDepositPage : ContentPage
    {
        public DirectDepositPage()
        {
            InitializeComponent();
            BindingContext = App.retiree.Direct_Deposit;
            }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Direct Deposit Page");
        }
    }
}
