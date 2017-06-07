using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Threading.Tasks;

using UXDivers.Artina.Shared;
using UXDivers.Artina.Shared.Droid;

using FFImageLoading.Forms.Droid;


namespace UFCW.Droid
{
	//https://developer.android.com/guide/topics/manifest/activity-element.html
	[Activity(
		Label = "UFCW",
		Icon = "@drawable/icon",
		Theme = "@style/Theme.Splash",
	 	MainLauncher = true,
		LaunchMode = LaunchMode.SingleTask,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize
		)
	]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			// Changing to App's theme since we are OnCreate and we are ready to 
			// "hide" the splash
			base.Window.RequestFeature(WindowFeatures.ActionBar);
			base.SetTheme(Resource.Style.AppTheme);


			FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
			FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabs;

			base.OnCreate(bundle);

			//Initializing FFImageLoading
			CachedImageRenderer.Init();

			global::Xamarin.Forms.Forms.Init(this, bundle);
			UXDivers.Artina.Shared.GrialKit.Init(this, "UFCW.Droid.GrialLicense");

			FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));

			LoadApplication(new App());

            Window.SetStatusBarColor(new Android.Graphics.Color(87, 169, 237));
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);

			DeviceOrientationLocator.NotifyOrientationChanged();
		}

	}

}

