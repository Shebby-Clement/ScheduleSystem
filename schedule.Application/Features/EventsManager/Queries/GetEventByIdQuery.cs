using schedule.Application.Messaging;
using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Queries
{
    public class GetEventByIdQuery : IQuery<Event>
    {
        public long EventId { get; set; }
    }
}
