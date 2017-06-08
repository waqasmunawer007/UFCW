using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Services.Models.User;
using UFCW.Services.UserService;

namespace UFCW.ViewModels
{
    public class LoginViewModel: INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        public User user;
		private string email;
		private string password;
        private bool isBusy = false;
		private bool showErrorLabel = false;

        public LoginViewModel()
        {
            
        }
        public List<SampleCategory> Items
		{
			get
			{
				return SamplesDefinition.SamplesCategoryList;
			}
		}
		public bool ShowError
		{
			get { return showErrorLabel; }
			set
			{
				if (showErrorLabel != value)
				{
					showErrorLabel = value;
					OnPropertyChanged("ShowError");
				}
			}
		}

		public string Email
		{
			get { return email; }
			set
			{
				if (email != value)
				{
					email = value;
					OnPropertyChanged("Email");
				}
			}
		}
		public string Password
		{
			get { return password; }
			set
			{
				if (password != value)
				{
					password = value;
					OnPropertyChanged("Password");
				}
			}
		}
		/// <summary>
		/// Gets or sets a value indicating for Activity Indicator.
		/// </summary>
		/// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
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
		/// <summary>
		/// Logis the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="email">Email.</param>
		/// <param name="password">Password.</param>
        public async Task<LoginResponse> LogiUser(string email, string password)
        {
            IsBusy = true;
            var loginService = new UserService();
            return await loginService.LoginUser(email, password);
        }
    }
}
