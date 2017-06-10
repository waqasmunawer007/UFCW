using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Services.Models.User;
using UFCW.Services.Services;
using System.Collections.Generic;
using System.Text;
using UFCW.Services.Services.EligibilityServices;
using UFCW.Services.Models.Eligibility;

namespace UFCW.Services.UserService
{
    public class Eligibility : BaseService, IEligibilityService
    {
       /// <summary>
       /// Fetchs the time loss.
       /// </summary>
       /// <returns>The time loss.</returns>
       /// <param name="Token">Token.</param>
       /// <param name="SSN">Ssn.</param>
       /// <param name="Email">Email.</param>
        public Task<TimeLossServerResponse> FetchTimeLoss(string Token, string SSN, string Email)
        {
            throw new NotImplementedException();
        }
    }
}
