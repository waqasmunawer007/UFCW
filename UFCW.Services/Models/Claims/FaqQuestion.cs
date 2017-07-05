using System;
namespace UFCW.Services
{
	public class FaqQuestion
	{
		public string FaqID { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public FaqCategory FaqCategory { get; set; }
		public string Tags { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
	}
}
public class FaqCategory
{
	public string FaqCategoryID { get; set; }
	public string CategoryName { get; set; }
	public string DateCreated { get; set; }
	public string DateUpdated { get; set; }
}