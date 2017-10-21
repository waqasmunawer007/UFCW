using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Claims;

namespace UFCW.Services.Services.Claims
{
    public class ClaimService:BaseService,IClaimService
    {
		
		/// <summary>
		/// Fetchs the claim detail.
		/// </summary>
		/// <returns>The claim detail.</returns>
		/// <param name="token">Token.</param>
		/// <param name="ssn">Ssn.</param>
		/// <param name="claimNumber">Claim number.</param>
		public async Task<ClaimDetail[]> FetchClaimDetail(string claimNumber)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
            parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
			parameters.Add(WebApiConstants.ClaimNumber, claimNumber);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.ClaimsDetailApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var claimDetailResponse = JsonConvert.DeserializeObject<ClaimDetail[]>(json);
					return claimDetailResponse;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchClaimDetail", ex.Message);
			}
			return null;
		}
		/// <summary>
		/// Fetchs the claim eob.
		/// </summary>
		/// <returns>The claim eob.</returns>
		/// <param name="token">Token.</param>
		/// <param name="ssn">Ssn.</param>
		/// <param name="claimNumber">Claim number.</param>
		public async Task<ClaimDetail[]> FetchClaimEOB(string claimNumber)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
			parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
			parameters.Add(WebApiConstants.ClaimNumber, claimNumber);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.ClaimsEOBApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var claimEobResponse = JsonConvert.DeserializeObject<ClaimDetail[]>(json);
					return claimEobResponse;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchClaimEob", ex.Message);
			}
			return null;
		}

		/// <summary>
		/// Fetchs the FAQ list.
		/// </summary>
		/// <returns>The FAQ.</returns>
		/// <param name="token">Token.</param>
		/// <param name="ssn">Ssn.</param>
		public async Task<FAQ[]> FetchFAQ()
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
			parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
			
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.FAQApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var faqResponse = JsonConvert.DeserializeObject<FAQ[]>(json);
					return faqResponse;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchFAQ", ex.Message);
			}
			return null;
		}
		/// <summary>
		/// Fetchs the search filters for Claims.
		/// </summary>
		/// <returns>The search filters.</returns>
		/// <param name="token">Token.</param>
		/// <param name="ssn">Ssn.</param>
		public async Task<ClaimFilters> FetchSearchFilters()
		{

			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
			parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
            parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.ClaimSearchOptionsApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				var claimsFilterResponse = JsonConvert.DeserializeObject<ClaimFilters>(json);
				return claimsFilterResponse;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchSearchFilters", ex.Message);
			}
			return null;
		}
		/// <summary>
        /// Searchs the claim based on provided search criteria
        /// </summary>
        /// <returns>The claim.</returns>
        /// <param name="parameters">Parameters.</param>
		public async Task<ClaimSearchResponse> SearchClaim(Dictionary<string, object> parameters)
        {
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.ClaimsSearchQueryAPi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				var searchResponse = JsonConvert.DeserializeObject<ClaimSearchResponse>(json);
				return searchResponse;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("SearchClaim Exception", ex.Message);
			}
			return null;
		}
	}
}
