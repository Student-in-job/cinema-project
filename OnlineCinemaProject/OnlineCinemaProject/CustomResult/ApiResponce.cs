using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace OnlineCinemaProject.CustomResult
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public string Version { get { return "1.2.3"; } }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        public ApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = (int)statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }

    public static class Util
    {
        public static String GetJsonString(Object content)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                content,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
        }
    }
}