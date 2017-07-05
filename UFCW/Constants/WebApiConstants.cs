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
        #endregion

        #region General Constants
        public const string API_MEDIA_TYPE = "application/json";

        #endregion
    }
}
