using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Models
{
    public class Email
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Model { get; set; }
        public string Template { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
