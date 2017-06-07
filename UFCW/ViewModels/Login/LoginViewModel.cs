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
        public bool isBusy = false;

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

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

        public async Task<LoginResponse> LogiUser(string email, string password)
        {
            IsBusy = true;
            var loginService = new UserService();
            return await loginService.LoginUser(email, password);
        }
    }
}
