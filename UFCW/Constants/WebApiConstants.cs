using System;
namespace UFCW.Constants
{
    public class WebApiConstants
    {
		#region API's
		public static string BenifitsApi = "Eligibility/BenefitPlans";
		public static string ParticipantApi = "Eligibility/Participant";
		public static string ChecksIssuedApi = "Eligibility/ChecksIssued";
		public static string TimeLossApi = "Eligibility/TimeLoss";
		public static string DependentsApi = "Eligibility/Dependents";
		#endregion

		#region Calims API's
		public static string FAQApi = "Claims/faq";
        public static string ClaimSearchOptionsApi = "Claims/SearchOptionList";
        public static string ClaimsSearchQueryAPi = "Claims/Query";
        public static string ClaimsDetailApi = "Claims/Detail";
        public static string ClaimsEOBApi = "Claims/EOB";
		#endregion


		#region Fields Constatns
		public const string TOKEN = "Token";
        public const string SSN = "SSN";
        public const string EMAIL = "Email";
		public const string ClaimStatus = "CLAIM_STATUS";
		public const string ClaimType = "CLAIM_TYPE";
        public const string SearchDate = "searchDate";
        public const string SearchPatient = "searchPatient";
        public const string SearchDependent = "searchDependent";
        public const string PageNumber = "start";
        public const string PageSize = "length";
		public const string FromDate = "FROM_DATE";
		public const string ToDate = "TO_DATE";
	    public const string ClaimNumber = "CLAIM_NUMBER";
        #endregion


        #region Error Codes
        public const int Error103 = 103; // Invalid Token request
        public const int Error104 = 104; //Token Expired

        #endregion

        #region General Constants
        public const string API_MEDIA_TYPE = "application/json";

        #endregion
    }
}
