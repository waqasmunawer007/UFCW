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
            InboxPage inboxPage = new InboxPage();
            Children.Add(inboxPage);
            Children.Add(new SentMessagePage());
            Children.Add(new ComposeMessagePage(null));

        }
    }
}
