using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace UFCW
{
	public class SamplesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private Sample _selectedSample;

		public SamplesViewModel(INavigation navigation)
		{
			SamplesCategories = new List<SampleCategory>(SamplesDefinition.SamplesCategories.Values);
			AllSamples = SamplesDefinition.AllSamples;
			SamplesGroupedByCategory = SamplesDefinition.SamplesGroupedByCategory;
		}

		public List<SampleCategory> SamplesCategories { get; set; }

		public List<Sample> AllSamples { get; set; }

		public List<SampleGroup> SamplesGroupedByCategory { get; set; }

		public Sample SelectedSample
		{
			get
			{
				return _selectedSample;
			}

			set
			{
				if (value != _selectedSample)
				{
					_selectedSample = value;

					RaisePropertyChanged("SelectedSample");
				}
			}
		}

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}