using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Constants;
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
        /// <summary>
        /// Fetchs the profile from server.
        /// </summary>
        /// <returns>The profile.</returns>
        async Task FetchProfile()
        {
			Profile profile = await participantDetailVM.FetchProfile();
            if (profile != null)
            {
                BindingContext = participantDetailVM.profile;
            }
            else
            {
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
        }

	}
}
