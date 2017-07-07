using System;
using System.Threading.Tasks;

namespace UFCW.Services.Services.Claims
{
    public interface IClaimService
    {
        Task<FAQ[]> FetchFAQ(string token, string ssn);
		Task<ClaimFilters> FetchSearchFilters(string token, string ssn);
		Task<ClaimDetail[]> SearchClaim(string token, string ssn,string ClaimType,string claimStatus,string fromData,string toDate);
		Task<ClaimDetail[]> FetchClaimDetail(string token, string ssn,string claimNumber);
		Task<ClaimDetail[]> FetchClaimEOB(string token, string ssn, string claimNumber);
    }
}
