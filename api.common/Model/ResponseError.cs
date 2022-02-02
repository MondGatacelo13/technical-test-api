using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Common.Models
{
    /// <summary>
    /// Class to be used when responding with an error to the customer
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Parameterless constructor for serialization
        /// </summary>
        public ResponseError()
        {

        }

        /// <summary>
        /// Constructor to handle just the message
        /// </summary>
        /// <param name="message">Sets the Message property</param>
        public ResponseError(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the HTTP Status code for the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message to return in the error.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Returns a JSON string of the serialized <see cref="ResponseErrorDetail"/> object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
