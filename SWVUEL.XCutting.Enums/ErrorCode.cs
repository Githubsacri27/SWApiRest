namespace SWVUEL.XCutting.Enums
{
    public enum ErrorCode
    {
        // General Errors
        UnknownError = 1000,
        ValidationFailed = 1001,

        // Not Found Errors
        StarshipNotFound = 2001,

        // Argument Errors
        InvalidId = 3001,
        EmptyOrNullName = 3002,
        EmptyOrNullModel = 3003,

        // Database Errors
        DatabaseConnectionFailed = 4001,
        DatabaseUpdateFailed = 4002,

        // Service Errors
        ServiceUnavailable = 5001
    }
}
