using System;
namespace UFCW.Constants
{
    public class AppConstants
	{
        public static Environment environment = Environment.STAGING;
		public static string BaseUrlStaging = "http://sinettechnologies.net/api/";
		public static string BaseUrlLive = "http://sinettechnologies.net/api/";
        public static string BaseUrl = BaseUrlLive;

        public static string LoginApi = "Login";


        public const string RESPONSE_CODE_OK = "200";
    }

    public enum Environment
    {
        LIVE,
        STAGING
    }
}
