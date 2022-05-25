namespace TedTalk.WebHost.HttpApi
{
    public class ApiError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string Type { get; set; }
        public string TraceId { get; set; }

        public ApiError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
