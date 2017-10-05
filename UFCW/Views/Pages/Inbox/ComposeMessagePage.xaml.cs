using System;
using System.Collections.Generic;
using System.Diagnostics;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ComposeMessagePage : ContentPage
    {
        ComposeMessageVM viewModel;
        private string messageID = "";
        public ComposeMessagePage(string messageID)
        {
            InitializeComponent();
            this.messageID = messageID;
            Title = "Compose Message";
            viewModel = new ComposeMessageVM(Navigation,messageID);
            BindingContext = viewModel;
        }
	}
}
