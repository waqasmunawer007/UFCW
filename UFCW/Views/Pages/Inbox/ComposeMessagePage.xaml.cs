using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ComposeMessagePage : ContentPage
    {
        public ComposeMessagePage()
        {
            InitializeComponent();
            Title = "Compose Message";
            picker.Title = "To";
			foreach (string colorName in contactsList.Keys)
			{
				picker.Items.Add(colorName);
			}

			picker.SelectedIndexChanged += (sender, args) =>
			{
				if (picker.SelectedIndex == -1)
				{
                    Debug.WriteLine("Selected Item: " + picker.SelectedItem.ToString());
				}
				else
				{
                    string selectedContact = picker.Items[picker.SelectedIndex];
                    Debug.WriteLine("Selected Item: " + selectedContact);
				}
			};
        }
        Dictionary<string, string> contactsList = new Dictionary<string, string>
		{
			{ "AddressChange", "AddressChange" },
			{ "ContactUs", "" },
			{ "PensionAdmin", "PensionAdmin" },
			{ "HWAdmin", "HWAdmin" },
		};
		void Handle_Clicked(object sender, System.EventArgs e)
		{
            //Navigation.PushAsync(new ComposeMessagePage());
            if (picker.SelectedIndex > -1)
            {
                Debug.WriteLine("Send Message " + "\nTo: " + picker.Items[picker.SelectedIndex]
                                + "\nSubject: " + SubjectInput.Text
                                + "\nMessage: " + MessageBody.Text);
            }else
            {
                Debug.WriteLine("All Fields are not filled...");
            }
		}
	}
}
