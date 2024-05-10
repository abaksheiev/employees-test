namespace WebTest.Contracts
{
    public static class Constants
    {
        public static class ResponseStatus { 
            public static string Success = "success";
            public static string Error = "error";
            public static string BadRequest = "bad data";
        }

        public static class ResponseMessages
        {
            public static string Success = "Success: All records have been fetched successfully.";
            public static string Error = "Error: An unexpected error occurred.";
            public static string BadRequest = "Error: Invalid or incomplete data provided.";
        }
    }
}
