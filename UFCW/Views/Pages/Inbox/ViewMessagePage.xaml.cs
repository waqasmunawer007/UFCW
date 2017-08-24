using System;
using System.Collections.Generic;
using UFCW.Services.Models.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ViewMessagePage : ContentPage
    {
        public ViewMessagePage(Message message)
        {
            InitializeComponent();
            BindingContext = message;
            Title = message.From;
        }
    }
}
