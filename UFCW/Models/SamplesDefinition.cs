using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UFCW.Views.Login;
using UFCW.Views.Navigation.Test;
using Xamarin.Forms;

namespace UFCW
{
	public static class SamplesDefinition
	{
		private static List<SampleCategory> _samplesCategoryList;
		private static List<SampleGroup> _samplesGroupedByCategory;
		private static Dictionary<string, SampleCategory> _samplesCategories;
		private static List<Sample> _allSamples;


		private static List<SampleGroup> _hamburgerMenuGroupedByCategory;
		//private static List<Sample> _hamburgerMenuSamples;


		public static string[] _categoriesColors = {
			"#ffffff",
			"#B31250",
			"#CD195E",
			"#56329A",
			"#6A40B9",
			"#7C4ECD",
			"#525ABB",
			"#5F7DD4",
			"#7B96E5"
		};

		public static List<SampleCategory> SamplesCategoryList
		{
			get
			{
				if (_samplesCategoryList == null)
				{
					InitializeSamples();
				}

				return _samplesCategoryList;
			}
		}

		public static Dictionary<string, SampleCategory> SamplesCategories
		{
			get
			{
				if (_samplesCategories == null)
				{
					InitializeSamples();
				}

				return _samplesCategories;
			}
		}

		public static List<Sample> AllSamples
		{
			get
			{
				if (_allSamples == null)
				{
					InitializeSamples();
				}
				return _allSamples;
			}
		}
		/// <summary>
		/// Gets the hamburger menu option grouped by category.
		/// </summary>
		/// <value>The hamburger menu grouped by category.</value>
		public static List<SampleGroup> HamburgerMenuGroupedByCategory
		{
			get
			{
				if (_hamburgerMenuGroupedByCategory == null)
				{
					InitializeHamubergerMenuOptions();
				}

				return _hamburgerMenuGroupedByCategory;
			}
		}

		public static List<SampleGroup> SamplesGroupedByCategory
		{
			get
			{
				if (_samplesGroupedByCategory == null)
				{
					InitializeSamples();
				}

				return _samplesGroupedByCategory;
			}
		}
		/// <summary>
		/// Creates the menu options for hamburger menu
		/// </summary>
		/// <returns>The hamburger menu options.</returns>
		internal static Dictionary<string, SampleCategory> CreateHamburgerMenuOptions()
		{ 
			var menuCategories = new Dictionary<string, SampleCategory>();

			menuCategories.Add(
				"HamburgerMenu",
				new SampleCategory
				{
					Name = "Menu",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.AccountCircle,
					IconColor = Color.FromHex(_categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					SamplesList = new List<Sample> {
					new Sample("Home", typeof(HomePage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Menu),
					new Sample("My Account", typeof(AccountPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
					new Sample("Pension", typeof(PensionPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
					new Sample("Documents", typeof(DocumentPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
					new Sample("Links", typeof(LinksPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
					new Sample("News", typeof(NewsPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
					new Sample("FAQ", typeof(FAQPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group)

					}
				}
			);
			return menuCategories;
		}
		internal static Dictionary<string, SampleCategory> CreateSamples()
		{
			var categories = new Dictionary<string, SampleCategory>();

            categories.Add(
                "LOGIN1",
                new SampleCategory
                {
                    Name = "Register",
                    BackgroundColor = Color.FromHex(_categoriesColors[0]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.AccountCircle,
                    IconColor = Color.FromHex(_categoriesColors[0]),
                    Badge = 2,
                	Shape = GrialShapesFont.Circle,
                    SamplesList = new List<Sample> {
                    new Sample("Item 1", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                    new Sample("Item 2", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                    new Sample("Item 3", typeof(TestPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
                    new Sample("Item 4", typeof(TestPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
                    new Sample("Item 5", typeof(TestPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

                    }
                }
            );
            categories.Add(
                "LOGIN2",
                new SampleCategory
                {
                    Name = "Forgot Password",
                    BackgroundColor = Color.FromHex(_categoriesColors[2]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Lock,
                    IconColor = Color.FromHex(_categoriesColors[0]),
                    Badge = 2,
               		 Shape = GrialShapesFont.Circle,
                    SamplesList = new List<Sample> {
                    new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                        new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                        new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
                        new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
                        new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

                    }
                }
            );
            categories.Add(
                "LOGIN3",
                new SampleCategory
                {
                    Name = "Notifications",
                    BackgroundColor = Color.FromHex(_categoriesColors[2]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Notifications,
                    IconColor = Color.FromHex(_categoriesColors[0]),    
                    Badge = 2,
                Shape = GrialShapesFont.Circle,
                    SamplesList = new List<Sample> {
                    new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                        new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

                        new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
                        new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
                        new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

                    }
                }
            );
            categories.Add(
                "LOGIN4",
                new SampleCategory
                {
                    Name = "Changed Device",
                    BackgroundColor = Color.FromHex(_categoriesColors[0]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
	                Icon = GrialShapesFont.PhoneAndroid,
	                IconColor = Color.FromHex(_categoriesColors[0]),
                    Badge = 5,
               Shape = GrialShapesFont.Circle,
                    SamplesList = new List<Sample> {
                    new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
                        new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

                        new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
                        new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
                        new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

                    }
                }
            );


			categories.Add(
				"LOGIN5",
				new SampleCategory
                {
                    Name = "Contact Us",
                    BackgroundColor = Color.FromHex(_categoriesColors[0]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
	                Icon = GrialShapesFont.Email,
	                IconColor = Color.FromHex(_categoriesColors[0]),
					Badge = 2,
                Shape = GrialShapesFont.Circle,
					SamplesList = new List<Sample> {
					new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
						new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
						new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

					}
				}
			);
			categories.Add(
				"LOGIN6",
				new SampleCategory
                {
                    Name = "FAQ",
                    BackgroundColor = Color.FromHex(_categoriesColors[0]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Help,
                    IconColor = Color.FromHex(_categoriesColors[0]),
					Badge = 2,
                   Shape = GrialShapesFont.Circle,
					SamplesList = new List<Sample> {
					new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
						new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
						new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

					}
				}
			);
			categories.Add(
				"LOGIN7",
				new SampleCategory
				{
					Name = "Live Chat",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Send,
                    IconColor = Color.FromHex(_categoriesColors[0]),
					Badge = 1,
                   Shape = GrialShapesFont.Circle,
					SamplesList = new List<Sample> {
					new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
						new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
						new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

					}
				}
			);
			categories.Add(
				"LOGIN8",
				new SampleCategory
				{
					Name = "Internet Banking",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Star,
                    IconColor = Color.FromHex(_categoriesColors[0]),
					Badge = 5,
					Shape = GrialShapesFont.Circle,
					SamplesList = new List<Sample> {
					new Sample("Document Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.AccountCircle),
						new Sample("Social", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),
						new Sample("Social Variant", typeof(LoginPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Group),

					}
				}
			);
			return categories;
		}

		internal static void InitializeHamubergerMenuOptions()
		{
			 Dictionary<string, SampleCategory> hamburgerMenuCategories = CreateHamburgerMenuOptions();
			 Debug.WriteLine("Samples Created: " + _samplesCategories.Count);
			//_samplesCategoryList = new List<SampleCategory>();

			//foreach (var sample in _hamburgerMenuCategories.Values)
			//{
			//	_samplesCategoryList.Add(sample);
			//}

			//_allSamples = new List<Sample>();

			_hamburgerMenuGroupedByCategory = new List<SampleGroup>();

			foreach (var sampleCategory in hamburgerMenuCategories.Values)
			{
				var sampleItem = new SampleGroup(sampleCategory.Name.ToUpper());

				foreach (var sample in sampleCategory.SamplesList)
				{
					//_allSamples.Add(sample);
					sampleItem.Add(sample);
				}
				_hamburgerMenuGroupedByCategory.Add(sampleItem);
			}
		}


		internal static void InitializeSamples()
		{
			_samplesCategories = CreateSamples();
            Debug.WriteLine("Samples Created: " + _samplesCategories.Count);
			_samplesCategoryList = new List<SampleCategory>();

			foreach (var sample in _samplesCategories.Values)
			{
				_samplesCategoryList.Add(sample);
			}

			_allSamples = new List<Sample>();

			_samplesGroupedByCategory = new List<SampleGroup>();

			foreach (var sampleCategory in SamplesCategories.Values)
			{

				var sampleItem = new SampleGroup(sampleCategory.Name.ToUpper());

				foreach (var sample in sampleCategory.SamplesList)
				{
					_allSamples.Add(sample);
					sampleItem.Add(sample);
				}

				_samplesGroupedByCategory.Add(sampleItem);
			}
		}

		private static void RootPageCustomNavigation(INavigation navigation)
		{
			SampleCoordinator.RaisePresentMainMenuOnAppearance();
			navigation.PopToRootAsync();
		}
	}

	public class SampleGroup : List<Sample>
	{
		private readonly string _name;

		public SampleGroup(string name)
		{
			_name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
}
