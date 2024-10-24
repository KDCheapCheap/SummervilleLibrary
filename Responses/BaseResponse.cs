namespace SummervilleLibrary.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse()
        {
            Success = false;
            Message = string.Empty;
        }
    }
}
