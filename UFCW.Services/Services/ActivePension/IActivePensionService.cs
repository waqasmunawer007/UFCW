using System;
using System.Threading.Tasks;
using UFCW.Services.Models.ActivePension;

namespace UFCW.Services.Services.ActivePension
{
    public interface IActivePensionService
    {
        Task<Profile> FetchProfile(); //Fetch user profile
        Task<CurrentYearContribution> FetchCurrentYearContribution(); //Fetch Current Year Contribution
        Task<HistoryByEmployer[]> FetchHistoryByEmployer(); //Fetch History By Emploer
        Task<HistoryByYear[]> FetchHistoryByYear(); //Fetch History By Year
        Task<MyBenifits> FetchBenifits(); //Fetch Benifits
        Task<PlanDocument[]> FetchDocuments(); //Fetch Documents
	}
}
