using System;
using System.Collections.Generic;

namespace UFCW.Services
{
	public class ClaimFilters
	{
		public List<ClaimType> ClaimTypes { get; set; }
		public List<ClaimStatus> ClaimStatuses { get; set; }
		public List<Patient> Patients { get; set; }
	}
}

public class ClaimType
{
	public bool Disabled { get; set; }
	public object Group { get; set; }
	public bool Selected { get; set; }
	public string Text { get; set; }
	public string Value { get; set; }
}

public class ClaimStatus
{
	public bool Disabled { get; set; }
	public object Group { get; set; }
	public bool Selected { get; set; }
	public string Text { get; set; }
	public string Value { get; set; }
}

public class Patient
{
	public bool Disabled { get; set; }
	public object Group { get; set; }
	public bool Selected { get; set; }
	public string Text { get; set; }
	public string Value { get; set; }
}