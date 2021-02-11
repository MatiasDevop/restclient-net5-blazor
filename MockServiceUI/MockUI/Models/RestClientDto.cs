using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MockUI.Models
{
    public class RestClientDto
    {
        public string EndPoint { get; set; }
        public int HttpMethod { get; set; }
        public string Parameter { get; set; }
    }
    public enum Method
    {
        [Display(Name = "POST")]
        GET,

        [Display(Name = "POST")]
        POST,

        [Display(Name = "PUT")]
        PUT,

        [Display(Name = "Delete")]
        DELETE
    }
}
