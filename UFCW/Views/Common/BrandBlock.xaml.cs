using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Models;
using Xamarin.Forms;

namespace UFCW
{
	public partial class BrandBlock : ContentView
	{
		public BrandBlock ()
		{
			InitializeComponent ();
            string pensionStatus = "";
			if (Settings.RetireeOrActive != null && Settings.RetireeOrActive.Equals(AppConstants.STRING_RETIRE))
			{
                pensionStatus = "Retiree";
			}
			else
			{
				pensionStatus = "Active";
			}
            Profile profile = new Profile(Settings.UserName,Settings.UserSSN,pensionStatus);
            BindingContext = profile;
		}
	}
}