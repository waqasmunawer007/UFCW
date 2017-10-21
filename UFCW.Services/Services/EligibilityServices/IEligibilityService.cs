using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Eligibility;
using UFCW.Services.Models.Eligibility.Benifits;

namespace UFCW.Services.Services.EligibilityServices
{
    public interface IEligibilityService
    {
        Task<Dependant[]> FetchDependents();
        Task<Benifits[]> FetchUserBenifits();
        Task<CheckIssued[]> FetchChecksIssued();
        Task<TimeLoss[]> FetchTimeLoss(); //Fetch TimeLoss
        Task<EligibilityReportResponse> FetchEligibilityReport(int pageNumber,int pageSize);
        Task<EligibilityDetail> FetchEligibilityDetail(String EligibilityID);
    }
}
