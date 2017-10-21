using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Pension;

namespace UFCW.Services.Services.Pension
{
    public interface IPensionService
    {
        Task<Retiree> FetchRetiree(); //Fetch Retiree
        Task<SummaryPlanDoc[]> FetchSummaryPlanDoc();//Fetch Sumary Plan Docs

	}
}
