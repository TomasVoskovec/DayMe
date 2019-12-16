using System;
using System.Collections.Generic;
using System.Text;

namespace DayMe.Models
{
    class ApiResponse
    {
        public string ResponseName { get; set; }
        public string Message { get; set; }

        public ApiResponse(string message)
        {
            this.Message = message;
        }
    }
}
