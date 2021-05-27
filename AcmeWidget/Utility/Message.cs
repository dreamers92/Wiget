using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AcmeWidget.Utility
{
    public class Message <T>
    {
        
            [JsonProperty("IsSuccess")]
            public bool IsSuccess { get; set; }

            //[DataMember(Name = "ReturnMessage")]
            //public string ReturnMessage { get; set; }
            [JsonProperty("Data")]


            public T Data { get; set; }

            [JsonProperty("DataList")]

            public List<T> DataList { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("CorrelationId")]
            public string CorrelationId { get; set; }

            [JsonProperty("ResponseTraceId")]
            public string ResponseTraceId { get; set; }

            [JsonProperty("Error")]
            public Error Error { get; set; }


    }
    [DataContract]
    public class Error
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

    }
}
