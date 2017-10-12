using System;
using System.Collections.Generic;
using System.Diagnostics;
using UFCW.Services.Models.Inbox;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ComposeMessagePage : ContentPage
    {
        ComposeMessageVM viewModel;
        private InBoxMessage inboxMessage = null;
        AdminMailbox mailbox = null;
        public ComposeMessagePage(InBoxMessage inboxMessage)
        {
            InitializeComponent();
            this.inboxMessage = inboxMessage;
            viewModel = new ComposeMessageVM(Navigation);
            BindingContext = viewModel;

            if (inboxMessage != null)
            {
                viewModel.MessageBody = inboxMessage.Body;
                if (!String.IsNullOrEmpty(inboxMessage.Subject))
                {
					string subString = inboxMessage.Subject.Substring(0, 3);
                    if (!subString.Equals("Re:"))
                    {
                        viewModel.Subject = "Re:" + inboxMessage.Subject;
                    }
                    else
                    {
                        viewModel.Subject =  inboxMessage.Subject;
                    }
                }
               
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.FetchAdmainMailbox();
            if (inboxMessage != null)
            {
				int index = viewModel.SelectedToContactIndex(inboxMessage.ToDescription);
				TypePicker.SelectedIndex = index;
				viewModel.ToContactSelectedIndex = index;
            }
        }
	}
}
