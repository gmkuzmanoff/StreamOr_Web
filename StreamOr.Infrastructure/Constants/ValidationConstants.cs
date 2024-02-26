namespace StreamOr.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        /// <summary>
        /// String Length Constants
        /// </summary>
        public const int RadioUrlMinL = 7;
        public const int RadioUrlMaxL = 200;
        /// <summary>
        /// Error messages
        /// </summary>
        public const string RequireErrorMessage = "The field {0} is required!";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters!";
    }
}
