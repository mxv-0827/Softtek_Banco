namespace ÄPI.Infrastructure.CustomExceptions
{
    public class APIErrorResponse
    {
        public int StatusCode { get; set; }
        public List<ErrorResponse> Error { get; set; }


        public class ErrorResponse
        {
            public string ErrorMessage { get; set; }
        }
    }
}
