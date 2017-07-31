using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;
using Xamarin.Forms;

namespace UFCW.ViewModels.NonCore
{
	public class LinksViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<LinkResponse> linksList;
		public ICommand VisitButtonCommand { get; set; }
		private bool isBusy = false;

		public LinksViewModel()
		{
           linksList = new ObservableCollection<LinkResponse>(); 

			VisitButtonCommand = new Command((e) =>
			{
				LinkResponse selectedItem = (e as LinkResponse);
				//EligibilityDetailPage detailPage = new EligibilityDetailPage(selectedItem);
				//detailPage.BindingContext = selectedItem;
				//await Navigation.PushAsync(detailPage);
			});
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

		public ObservableCollection<LinkResponse> LinksList
		{
			get { return linksList; }
			set
			{
				if (linksList != value)
				{
					linksList = value;
					OnPropertyChanged("LinksList");
				}
			}
		}

		/// <summary>
        /// Fetchs the public links.
        /// </summary>
        /// <returns>The public links.</returns>
		public async Task FetchPublicLinks()
		{
			IsBusy = true;
			var service = new NonCoreService();
			//NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			//if (responseData != null)
			//{
			//             foreach (LinkResponse link in responseData.Links)
			//	{

			//                 this.LinksList.Add(link);
			//	}
			//             Debug.WriteLine("Total links " + LinksList.Count);
			//}
			for (int i = 0; i < 3; i++)
			{
                LinkResponse linkResponse = new LinkResponse();
                linkResponse.LinkCategory = "Health & Welfare Links";
                List<Link> links = new List<Link>();
                Link link = new Link();
                link.Url = "http://www.cigna.com/";
                links.Add(link);
                linkResponse.Links = links;     
				
                this.LinksList.Add(linkResponse);

			}
			IsBusy = false;
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

