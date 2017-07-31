using System;
namespace UFCW.Constants
{
    public class AppConstants
	{
        public static Environment environment       = Environment.STAGING;
		public static string BaseUrlStaging         = "http://sinettechnologies.net/api/";
		public static string BaseUrlLive            = "http://sinettechnologies.net/api/";
        public static string BaseWebAppURL           = "http://sinettechnologies.net";
        public static string BaseUrl                = BaseUrlLive;

        public static string LoginApi               = "Login";
        public static string TimeLossApi            = "Eligibility/TimeLoss";
        public static string PensionRetireeApi      = "PensionRetiree";
		public static string SummaryPlanDocApi      = "PensionRetiree/SummaryPlanDocuments";

		//Active pension
		public static string AP_ProfileApi              = "Pension/Profile";
		public static string AP_BenifitsApi             = "PensionActive/MyBenefits";
		public static string AP_CrntYrContributionApi   = "PensionActive/CurrentYearContribution";
		public static string AP_ContHistoryEmployerApi  = "PensionActive/HistoryByEmployer";
		public static string AP_ContHistoryYearApi      = "PensionActive/HistoryByYear";
		public static string AP_DocumentsApi            = "PensionActive/SummaryPlanDocuments";

       

        public const string RESPONSE_CODE_OK        = "200";
        public const string STRING_TRUE = "True";
		public const string STRING_FALSE = "False";
		public const string STRING_RETIRE = "Retiree";
		public const string STRING_ACTIVE = "Active";
		//Error Strings
		public const string ERROR_MESSAGE           = "Something went wrong. Please check your internet settings and then try again.";
        public const string Empty_Data_MESSAGE      = "No data found";
		public const string ERROR_TITLE             = "Error";
		public const string DIALOG_OK_OPTION        = "Try again!";
		public const string LOGIN_FAILED            = "Login Failed!";


    }

    public enum Environment
    {
        LIVE,
        STAGING
    }
}
