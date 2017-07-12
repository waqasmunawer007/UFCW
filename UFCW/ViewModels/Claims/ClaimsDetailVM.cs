using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using UFCW.Views.Pages.Claim;
using Xamarin.Forms;

namespace UFCW.ViewModels.Claims
{
    public class ClaimsDetailVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ClaimsDetailVM(INavigation mainPageNav)
        {
			Navigation = mainPageNav;
			SetupCommands();
        }

        INavigation Navigation;
        public ICommand EOBClickedCommand { get; set; }

        /// <summary>
        /// Setups the commands for Resest,Search And Detail buttons.
        /// </summary>
        private void SetupCommands()
        {
            EOBClickedCommand = new Command(() =>
           {
                Debug.WriteLine("Opening EOB PAge...");
                //EOBPage pageEOB = new EOBPage();
                //Navigation.PushAsync(pageEOB);
           });
        }

		/// <summary>
		/// Ons the property changed.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
}
