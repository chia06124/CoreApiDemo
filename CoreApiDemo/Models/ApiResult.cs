using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class ApiResult<T>
    {

        public bool Succ { get; set; }
        public string Code { get; set; }
        public string? Message { get; set; }
        public DateTime DataTime { get; set; }
        public T Data { get; set; }
        public ApiResult() { 
        }
        public ApiResult(T data)
        {
            Code = "0000";
            Succ = true;
            DataTime = DateTime.Now;
            Data = data;
        }
    }
    public class ApiError : ApiResult<object>
    { 
        public ApiError(string code, string message)
        {
            Code = code;
            Succ = false;
            this.DataTime = DateTime.Now;
            Message = message;
            Data = null;
        }
    }
}


