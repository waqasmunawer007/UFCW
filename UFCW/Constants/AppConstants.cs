using System;
namespace UFCW.Constants
{
    public class AppConstants
	{
        public static Environment environment       = Environment.STAGING;
		public static string BaseUrlStaging         = "http://sinettechnologies.net/api/";
		public static string BaseUrlLive            = "http://sinettechnologies.net/api/";
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

        //Google Analytics event messages
        public const string Login_Event_Message = "login button clicked";
        public const string HistoryByYear_Message = "Contribution History By Year Item Selected Event";
        public const string HistoryByEmployer_Message = "Contribution History By Employer Item Selected Event";
        public const string Dependant_Event_Message = "Eligibility Dependant Item Selected Event";
        public const string TimeLoss_Event_Message = "TimeLoss Item Selected Event";
        public const string CheckedIssued_Event_Messae = "Checked Issued Item Selected Event";

    }

    public enum Environment
    {
        LIVE,
        STAGING
    }
}
