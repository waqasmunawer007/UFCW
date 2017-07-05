using System;
using System.Threading.Tasks;

namespace UFCW.Services.Services.Claims
{
    public interface IClaimService
    {
        Task<FAQ[]> FetchFAQ(string token, string ssn);
    }
}
