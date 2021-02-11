using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Models
{
    public class MockResponse : BaseEntity
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseBody { get; set; }
    }
}
