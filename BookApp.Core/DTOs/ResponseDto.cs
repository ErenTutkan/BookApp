using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseDto<T> Success(T data,int statusCode = 0)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(int statusCode = 0)
        {
            return new ResponseDto<T> { Data=default(T), StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(List<string> errors,int statusCode = 0)
        {
            return new ResponseDto<T>{ Data=default(T),Errors=errors, StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(int statusCode=0)
        {
            return new ResponseDto<T>{ Data=default(T),Errors=null, StatusCode = statusCode };
        }
    }
}
