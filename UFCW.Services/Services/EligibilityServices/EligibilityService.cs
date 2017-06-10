﻿using System;
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
    public class EligibilityService : BaseService, IEligibilityService
    {
       /// <summary>
       /// Fetchs the time loss.
       /// </summary>
       /// <returns>The time loss.</returns>
       /// <param name="Token">Token.</param>
       /// <param name="SSN">Ssn.</param>
       /// <param name="Email">Email.</param>
        public async Task<TimeLoss[]> FetchTimeLoss(string Token, string SSN, string Email)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Token", Token);
            parameters.Add("SSN", SSN);
            parameters.Add("Email", Email);

			var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
			HttpResponseMessage responseJson = await client.PostAsync(AppConstants.TimeLossApi, content);
			var json = await responseJson.Content.ReadAsStringAsync();

            var timeLossResponse = JsonConvert.DeserializeObject<TimeLoss[]>(json);
			return timeLossResponse;

        }
    }
}
