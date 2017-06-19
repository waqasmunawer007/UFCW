using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UFCW
{
	public class SampleCategory
	{
		public string Name { get; set; }

		public Color BackgroundColor { get; set; }
		public Color IconColor { get; set; }

		public String BackgroundImage { get; set; }

        public List<Sample> SamplesList { get; set; }

		public string Icon { get; set; }
        public string Shape { get; set; }
		public int Badge { get; set; }
        public Page page { get; set; }

	}
}