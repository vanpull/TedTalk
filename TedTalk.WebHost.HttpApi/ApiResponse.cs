namespace TedTalk.WebHost.HttpApi
{
    public class ApiResponse
    {
        public int Status { get; set; }

        public bool Succeeded { get; }

        public bool IsFailed => !Succeeded;

        public string Message { get; set; }

        public object Error { get; set; }

        public object Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool succeeded, string message, object data = null, int statusCode = 200)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
            Status = statusCode;
        }

        public ApiResponse(string message, int statusCode, object apiError)
        {
            Succeeded = false;
            Message = message;
            Status = statusCode;
            Error = apiError;
        }
    }

    public class OkResponse : ApiResponse
    {
        public OkResponse(string message, object data = null)
            : base(true, message, data, 200)
        {

        }

        public OkResponse() { }
    }

    public class ServerErrorResponse : ApiResponse
    {
        public ServerErrorResponse(string message, object data = null)
            : base(false, message, data, 500)
        {

        }

        public ServerErrorResponse() { }
    }
}
