﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Services.Models.Claims;

namespace UFCW.Services.Services.Claims
{
    public interface IClaimService
    {
        Task<FAQ[]> FetchFAQ();
		Task<ClaimFilters> FetchSearchFilters();
		Task<ClaimSearchResponse> SearchClaim(Dictionary<string, object> parameters);
		Task<ClaimDetail[]> FetchClaimDetail(string claimNumber);
		Task<ClaimDetail[]> FetchClaimEOB(string claimNumber);
    }
}
