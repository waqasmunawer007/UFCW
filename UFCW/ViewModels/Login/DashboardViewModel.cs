using System.Collections.Generic;
using System.Diagnostics;

namespace UFCW
{
	public class DashboardViewModel
	{
		public List<SampleCategory> Items
		{
			get
			{
                Debug.WriteLine("SamplesCategoryList: " + SamplesDefinition.SamplesCategoryList.Count);
				return SamplesDefinition.SamplesCategoryList;
			}
		}
	}
}