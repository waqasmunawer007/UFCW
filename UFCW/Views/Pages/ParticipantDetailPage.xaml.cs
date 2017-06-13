using System;
using System.Collections.Generic;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW
{
	public partial class ParticipantDetailPage : ContentPage
	{
        //ParticipantsViewModel participantsVM;
		public ParticipantDetailPage()
		{
			InitializeComponent();
			//participantsVM = new ParticipantsViewModel();
			BindingContext = App.user;
            //FetchParticipants();
		}
	}
}
