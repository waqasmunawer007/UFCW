using System;
using UFCW;
using UFCW.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryRenderer))]
namespace UFCW.Droid
{
	public class LoginEntryRenderer: EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Gravity = Android.Views.GravityFlags.Center;
			}
		}
	}
}
