using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MockServiceApi.Dtos
{
    public class RestClientDto
    {
        public string EndPoint { get; set; }
        public int HttpMethod { get; set; }
        public string Parameter { get; set; }
    }
}
