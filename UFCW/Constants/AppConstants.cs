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
        public static string TimeLossApi = "Eligibility/TimeLoss";


        public const string RESPONSE_CODE_OK = "200";
		//Error Strings
		public const string ERROR_MESSAGE = "Something went wrong. Please check your internet settings and then try again.";
		public const string ERROR_TITLE = "Error";
		public const string DIALOG_OK_OPTION = "Try again!";
		public const string LOGIN_FAILED = "Login Failed!";


    }

    public enum Environment
    {
        LIVE,
        STAGING
    }
}
