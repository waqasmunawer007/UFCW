using System;
using System.Threading.Tasks;
using UFCW.Services.Models.ActivePension;

namespace UFCW.Services.Services.ActivePension
{
    public interface IActivePensionService
    {
        Task<Profile> FetchProfile(String Token, String SSN); //Fetch user profile
        Task<CurrentYearContribution> FetchCurrentYearContribution(String Token, String SSN); //Fetch Current Year Contribution
        Task<HistoryByEmployer[]> FetchHistoryByEmployer(String Token, String SSN); //Fetch History By Emploer
        Task<HistoryByYear[]> FetchHistoryByYear(String Token, String SSN); //Fetch History By Year
        Task<MyBenifits> FetchBenifits(String Token, String SSN); //Fetch Benifits
        Task<PlanDocument[]> FetchDocuments(String Token, String SSN); //Fetch Documents
	}
}
