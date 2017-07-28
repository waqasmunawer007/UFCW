using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Services.Models.Claims;

namespace UFCW.Services.Services.Claims
{
    public interface IClaimService
    {
        Task<FAQ[]> FetchFAQ(string token, string ssn);
		Task<ClaimFilters> FetchSearchFilters(string token, string ssn);
		Task<ClaimSearchResponse> SearchClaim(Dictionary<string, object> parameters);
		Task<ClaimDetail[]> FetchClaimDetail(string token, string ssn,string claimNumber);
		Task<ClaimDetail[]> FetchClaimEOB(string token, string ssn, string claimNumber);
    }
}
