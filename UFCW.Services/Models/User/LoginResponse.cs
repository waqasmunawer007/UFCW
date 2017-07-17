using System;
namespace UFCW.Services.Models.User
{
    public class LoginResponse: BaseResponse
    {
        public string Token;
        public User Profile;
		public string RetireeOrActive { get; set; }
		public string InsuranceEnrolled { get; set; }
		public string PensionEnrolled { get; set; }
    }
}
