using Microsoft.AspNetCore.Mvc;

namespace ÄPI.Infrastructure.CustomExceptions
{
    public static class ResponseFactory
    {
        public static IActionResult CreateSuccessResponse(int statusCode, object? data)
        {
            var response = new APISuccessResponse
            {
                StatusCode = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }


        public static IActionResult CreateErrorResponse(int statusCode, params string[] errorMessages)
        {
            var response = new APIErrorResponse
            {
                StatusCode = statusCode,
                Error = new List<APIErrorResponse.ErrorResponse>()
            };

            foreach (var error in errorMessages)
            {
                response.Error.Add(new APIErrorResponse.ErrorResponse
                {
                    ErrorMessage = error
                });
            }

            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
    }
}
