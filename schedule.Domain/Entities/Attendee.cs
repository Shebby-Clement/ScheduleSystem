using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Domain.Entities
{
    public class Attendee : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Event Event { get; set; }
    }
}
