using System;

namespace UFCW
{
	public class SampleCoordinator
	{
		public static event EventHandler<SampleEventArgs> SelectedSampleChanged;
		public static event EventHandler<EventArgs> PresentMainMenuOnAppearance;
		public static event EventHandler<SampleEventArgs> SampleSelected;

		private static Sample _selectedSample = null;

		public static void RaisePresentMainMenuOnAppearance()
		{
			if (PresentMainMenuOnAppearance != null)
			{
				PresentMainMenuOnAppearance(typeof(SampleCoordinator), null);
			}
		}

		public static void RaiseSampleSelected(Sample sample)
		{
			if (SampleSelected != null)
			{
				SampleSelected(typeof(SampleCoordinator), new SampleEventArgs(sample));
			}
		}

		public static Sample SelectedSample
		{
			get
			{
				return _selectedSample;
			}

			set
			{
				if (_selectedSample != value)
				{
					_selectedSample = value;

					if (SelectedSampleChanged != null)
					{
						SelectedSampleChanged(typeof(SampleCoordinator), new SampleEventArgs(value));
					}
				}
			}
		}
	}

	public class SampleEventArgs : EventArgs
	{
		private readonly Sample _sample;

		public SampleEventArgs(Sample newSample)
		{
			_sample = newSample;
		}

		public Sample Sample
		{
			get
			{
				return _sample;
			}
		}
	}
}