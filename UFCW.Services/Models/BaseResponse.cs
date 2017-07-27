﻿using System;
namespace UFCW.Services.Models
{
    public class BaseResponse
    {
        int Draw { get; set; }
        int RecordsTotal { get; set; }
        int RecordsFiltered { get; set; }
		public string APIName { get; set; }
		public int ErrorCode { get; set; }
		public string ErrorText { get; set; }
		public string ErrorDetails { get; set; }

        public BaseResponse() {}
    }
}
