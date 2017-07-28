using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Eligibility;
using UFCW.Services.Models.Eligibility.Benifits;

namespace UFCW.Services.Services.EligibilityServices
{
    public interface IEligibilityService
    {
        Task<Dependant[]> FetchDependents(string token, string SSN, string email);
        Task<Benifits[]> FetchUserBenifits(string token, string SSN, string email);
        Task<CheckIssued[]> FetchChecksIssued(string token, string SSN, string email);
        Task<TimeLoss[]> FetchTimeLoss(String Token,String SSN, String Email); //Fetch TimeLoss
        Task<EligibilityReportResponse> FetchEligibilityReport(String Token, String SSN, int pageNumber,int pageSize);
        Task<EligibilityDetail> FetchEligibilityDetail(String Token, String SSN, String EligibilityID);
    }
}
