using System;
using System.Collections.Generic;

namespace UFCW.Services.Models.Claims
{
    public class ClaimSearchResponse:BaseResponse
    {
        public List<ClaimDetail> Data { get; set; }
    }
}
