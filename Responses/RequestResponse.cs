namespace SummervilleLibrary.Responses
{
    public class RequestResponse<T> : BaseResponse
    {
        public T? Data { get; set; }

        public RequestResponse(bool success, string message, T? data = default) : base(success, message)
        {
            Data = data;
        }

        public RequestResponse() : base()
        {
            Success = false;
            Message = string.Empty;
            Data = default;
        }
    }
}