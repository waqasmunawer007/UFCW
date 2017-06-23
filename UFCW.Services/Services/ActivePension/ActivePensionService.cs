using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;

namespace UFCW.Services.Services.ActivePension
{
    public class ActivePensionService : BaseService, IActivePensionService
    {
        /// <summary>
        /// Fetchs the benifits.
        /// </summary>
        /// <returns>The benifits.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<MyBenifits> FetchBenifits(string Token, string SSN)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_BenifitsApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();

				var benefitsData = JsonConvert.DeserializeObject<MyBenifits>(json);
				return benefitsData;
            }
            catch(Exception ex)
            {
              Debug.WriteLine("ActivePensionFetchBenifits", ex.Message);  
            }
            return null;
        }

        /// <summary>
        /// Fetchs the current year contribution.
        /// </summary>
        /// <returns>The current year contribution.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<CurrentYearContribution> FetchCurrentYearContribution(string Token, string SSN)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_CrntYrContributionApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				var contributionData = JsonConvert.DeserializeObject<CurrentYearContribution>(json);
				return contributionData;
            }
            catch(Exception ex)
            {
              Debug.WriteLine("FetchCurrentYearContribution", ex.Message);  
            }
            return null;
        }

        /// <summary>
        /// Fetchs the documents.
        /// </summary>
        /// <returns>The documents.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<PlanDocument[]> FetchDocuments(string Token, string SSN)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_DocumentsApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var planDocumentsData = JsonConvert.DeserializeObject<PlanDocument[]>(json);
					return planDocumentsData;
				}
            }
            catch(Exception ex)
            {
                Debug.WriteLine("FetchDocuments", ex.Message);
			}
            return null;
        }

        /// <summary>
        /// Fetchs the history by emploer.
        /// </summary>
        /// <returns>The history by emploer.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<HistoryByEmployer[]> FetchHistoryByEmployer(string Token, string SSN)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_ContHistoryEmployerApi, content);
                string json = await responseJson.Content.ReadAsStringAsync();
                if (!json.Equals("[]")) //only parse json if it contains data
                {
					var historyData = JsonConvert.DeserializeObject<HistoryByEmployer[]>(json);
					return historyData;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("FetchEmployerHistory",ex.Message);    
            }
            return null;
        }

        /// <summary>
        /// Fetchs the history by year.
        /// </summary>
        /// <returns>The history by year.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<HistoryByYear[]> FetchHistoryByYear(string Token, string SSN)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_ContHistoryYearApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var historyByYearData = JsonConvert.DeserializeObject<HistoryByYear[]>(json);
					return historyByYearData;
				}
				
            }
            catch(Exception ex)
            {
                Debug.WriteLine("FetchHistoryByYear", ex.Message);
			}
            return null;
        }

        /// <summary>
        /// Fetchs the profile.
        /// </summary>
        /// <returns>The profile.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
        public async Task<Profile> FetchProfile(string Token, string SSN)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_ProfileApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				var profile = JsonConvert.DeserializeObject<Profile>(json);
				return profile;
            }
            catch(Exception ex)
            {
                 Debug.WriteLine("ActivePensionFetchProfile", ex.Message);   
            }
            return null;
		}
    }
}
