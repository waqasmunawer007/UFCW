using System;
using System.Collections.Generic;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW
{
	public partial class ParticipantDetailPage : ContentPage
	{
        ParticipantsViewModel participantsVM;
		public ParticipantDetailPage()
		{
			InitializeComponent();
			participantsVM = new ParticipantsViewModel();
			BindingContext = participantsVM;
            ParticipantsList.ItemsSource = participantsVM.participantsList;
            FetchParticipants();
		}
		public async void FetchParticipants()
		{
			participantsVM.IsBusy = true;
            Participant[] participants = await participantsVM.FetchParticipants();
			UpdatePage(participants);
			participantsVM.IsBusy = false;
		}

		private void UpdatePage(Participant[] data)
		{
            foreach (Participant participant in data)
			{
                participantsVM.participantsList.Add(participant);
			}
		}
	}
}
