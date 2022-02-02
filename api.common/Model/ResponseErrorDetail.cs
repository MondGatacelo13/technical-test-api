namespace api.Common.Models
{
    /// <summary>
    /// Class used to house the error details for the exception middle-ware, Response Error, fluent validation, etc.
    /// </summary>
    public class ResponseErrorDetail
    {
        /// <summary>
        /// Gets or sets the error code if one exists
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the message for the error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets any additional information about the message or error
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the help URL if one exists for this error
        /// </summary>
        public string HelpLink { get; set; }
    }
}
