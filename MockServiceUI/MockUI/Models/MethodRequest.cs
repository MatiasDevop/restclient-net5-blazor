using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockUI.Models
{
    public class MethodRequest
    {
        public int id { get; set; }
        public string Name { get; set; }

        public List<MethodRequest> GetMethodRequest()
        {
            var list =  new List<MethodRequest>
            {
                new MethodRequest { id = 0, Name = "GET"},
                new MethodRequest { id = 1, Name = "POST" },
                new MethodRequest { id = 2, Name = "PUT" },
                new MethodRequest { id = 3, Name = "DELETE" },
            };

            return  list;
        }
    }
}
