using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Models
{
    public class RestClient : BaseEntity
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
    }

    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
    }
}
