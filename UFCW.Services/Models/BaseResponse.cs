﻿using System;
namespace UFCW.Services.Models
{
    public class BaseResponse
    {
		public string APIName { get; set; }
		public int ErrorCode { get; set; }
		public string ErrorText { get; set; }
		public string ErrorDetails { get; set; }

        public BaseResponse() {}
    }
}
