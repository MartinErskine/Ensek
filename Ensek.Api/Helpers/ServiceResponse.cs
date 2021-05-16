using System.Net;

namespace Ensek.Api.Helpers
{
    /// <summary>
    /// Response wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ServiceResponse() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        public ServiceResponse(HttpStatusCode? errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        public ServiceResponse(HttpStatusCode? errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ServiceResponse(T data)
        {
            Data = data;
        }

        public HttpStatusCode? ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public bool IsError
        {
            get
            {
                return ErrorCode.HasValue || !string.IsNullOrEmpty(ErrorDescription);
            }
        }

        public T Data { get; set; }

        public static ServiceResponse<T> Error(string message)
        {
            return new ServiceResponse<T>()
            {
                ErrorCode = HttpStatusCode.NotAcceptable,
                ErrorDescription = message
            };
        }

        public static ServiceResponse<T> NotFound(string subject)
        {
            return new ServiceResponse<T>()
            {
                ErrorCode = HttpStatusCode.NotFound,
                ErrorDescription = $"{subject} does not exist."
            };
        }

        public static ServiceResponse<T> Success(T responseModel)
        {
            return new ServiceResponse<T>(responseModel);
        }
        public static ServiceResponse<T> Empty()
        {
            return new ServiceResponse<T>(default(T));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public ServiceResponse()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        public ServiceResponse(HttpStatusCode? errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        public ServiceResponse(HttpStatusCode? errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public HttpStatusCode? ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public bool IsError
        {
            get
            {
                return ErrorCode.HasValue || !string.IsNullOrEmpty(ErrorDescription);
            }
        }
    }
}
