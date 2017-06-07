using System.Collections.Generic;
using System.Linq;

namespace UFCW
{
	public static class SampleData
	{
		private static string[] _names;
        private static List<string> _loginImageGalleryItems;

        public static List<string> LoginImageGalleryItems
		{
			get
			{
				if (_loginImageGalleryItems == null)
				{
					_loginImageGalleryItems = InitLoginImageGalleryItems();
				}

				return _loginImageGalleryItems;
			}
		}


        private static List<string> InitLoginImageGalleryItems()
		{
			return new List<string>() {
				"user_profile_1@2x.jpg"
			};
		}
    }

	
}
