using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Dtos
{
    public class MockResponseDto
    {
        public string EndPoint { get; set; }
        public int HttpMethod { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseBody { get; set; }
    }
}
