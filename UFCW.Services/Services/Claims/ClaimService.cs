using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;

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
		public async Task<ClaimDetail[]> FetchClaimDetail(string token, string ssn, string claimNumber)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
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
		public async Task<ClaimDetail[]> FetchClaimEOB(string token, string ssn, string claimNumber)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
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
		public async Task<FAQ[]> FetchFAQ(string token, string ssn)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
			
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
		public async Task<ClaimFilters> FetchSearchFilters(string token, string ssn)
		{

			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
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
		/// Searchs the claim based on different filters value.
		/// </summary>
		/// <returns>The claim.</returns>
		/// <param name="token">Token.</param>
		/// <param name="ssn">Ssn.</param>
		/// <param name="ClaimType">Claim type.</param>
		/// <param name="claimStatus">Claim status.</param>
		/// <param name="fromData">From data.</param>
		/// <param name="toDate">To date.</param>
		public async Task<Claim[]> SearchClaim(string token, string ssn, string claimType, string claimStatus, string fromDate, string toDate)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
			parameters.Add(WebApiConstants.ClaimType, claimType);
			parameters.Add(WebApiConstants.ClaimStatus, claimStatus);
			parameters.Add(WebApiConstants.FromDate, fromDate);
			parameters.Add(WebApiConstants.ToDate, toDate);

			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.ClaimsSearchQueryAPi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var searchResponse = JsonConvert.DeserializeObject<Claim[]>(json);
					return searchResponse;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("SearchClaim", ex.Message);
			}
			return null;
		}
	}
}
