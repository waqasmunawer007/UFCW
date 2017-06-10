using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Eligibility;

namespace UFCW.Services.Services.EligibilityServices
{
    public interface IEligibilityService
    {
        Task<TimeLossServerResponse> FetchTimeLoss(String Token,String SSN, String Email); //Fetch TimeLoss
	}
}
