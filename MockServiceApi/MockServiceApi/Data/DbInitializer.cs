using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            //add mock response account for test
            Guid mockId = new Guid("c193f46c-ac49-4614-a358-9660e25e6f73");
            if (!context.MockResponses.Any())
            {
                var mock = new MockResponse()
                {
                    EndPoint = "https://jsonplaceholder.typicode.com/users",
                    HttpMethod = (HttpVerb)1,
                    ResponseBody = "Hellow World",
                    ResponseCode = 200
                };
                var mock2 = new MockResponse()
                {
                    EndPoint = "https://jsonplaceholder.typicode.com",
                    HttpMethod = (HttpVerb)3,
                    ResponseBody = "Not found",
                    ResponseCode = 400
                };

                context.MockResponses.Add(mock);
                context.MockResponses.Add(mock2);
                context.SaveChanges();
            }
        }
    }
}
