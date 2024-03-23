using System.Net;

namespace Report.Contracts
{
    public class ApiResult<T>
    {
        public bool IsSuccess => Failures == null;

        public HttpStatusCode StatusCode { get; set; }
        
        public T Data { get; set; }

        public IEnumerable<string> Failures { get; set; }

        public static ApiResult<T> Success(T data)
        {
            return new ApiResult<T>
            {
                StatusCode = HttpStatusCode.OK,
                Data = data,
                Failures = null
            };
        }

        public static ApiResult<T> Fail(IEnumerable<string> failures, HttpStatusCode statusCode)
        {
            return new ApiResult<T>
            {
                StatusCode = statusCode,
                Data = default,
                Failures = failures
            };
        }
    }
}