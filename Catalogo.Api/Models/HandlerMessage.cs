using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalogo.Api.Models
{
    public class HandlerMessage
    {
        public HandlerMessage(HttpStatusCode statusCode, string message)
        {
            Version = "v1";
            StatusCode = statusCode;
            Message = message;
        }

        public HandlerMessage(HttpStatusCode statusCode, string message, object result)
        {
            Version = "v1";
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]

        public string Version { get; set; }

        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }
   
    }
}
