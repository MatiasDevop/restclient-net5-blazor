using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockUI.Models
{
    public class MockResponse
    {
        public Guid Id { get; set; }
        public string EndPoint { get; set; }
        public int HttpMethod { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseBody { get; set; }
    }
}
