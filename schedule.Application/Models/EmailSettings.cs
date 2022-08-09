using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Models
{
    public class EmailSettings
    {
        public string AdminUser { get; set; }
        public string AdminPassword { get; set; }
        public string SMTPName { get; set; }
        public int SMTPPort { get; set; }
        public string EmailFrom { get; set; }
    }
}
