using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class MailboxTabbedPage : TabbedPage
    {
        public MailboxTabbedPage()
        {
            InitializeComponent();
            Children.Add(new ComposeMessagePage());
            Children.Add(new InboxPage());
            Children.Add(new SentMessagePage());
        }
    }
}
