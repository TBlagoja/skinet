﻿namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            
        }
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, It was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate",
                _ => null,
            };
        }
    }
}
