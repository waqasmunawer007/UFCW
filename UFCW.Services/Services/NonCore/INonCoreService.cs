using System;
using System.Threading.Tasks;
using UFCW.Services.Models.NonCore;

namespace UFCW.Services.Services.NonCore
{
    public interface INonCoreService
    {
		Task<NonCoreResponse> FetchPublicNonCoreData();
        Task<NonCoreResponse> FetchAuthNonCoreData(string token,string ssn,string email);
    }
}
