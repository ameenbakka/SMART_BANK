using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNT.Application
{
    public class ApiResponse<T>
    {
        public int StatusCode {  get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public ApiResponse(int statuscode, string message, T data = default)
        {
            StatusCode = statuscode;
            Message = message;
            Data = data;
        }
    }
}
