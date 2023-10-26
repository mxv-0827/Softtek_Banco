namespace ÄPI.Infrastructure.CustomExceptions
{
    public class APISuccessResponse
    {
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
