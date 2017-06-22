using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class ParticipantDetailPage : ContentPage
    {
        ParticipantDetailVM participantDetailVM;
        public ParticipantDetailPage()
        {
            InitializeComponent();
            participantDetailVM = new ParticipantDetailVM();
            FetchProfile();
        }

        async Task FetchProfile()
        {
			await participantDetailVM.FetchProfile();
			BindingContext = participantDetailVM.profile;
        }

	}
}
