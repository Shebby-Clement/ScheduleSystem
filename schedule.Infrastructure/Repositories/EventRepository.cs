
using schedule.Application.Contracts.Persistence;
using schedule.Domain.Entities;
using schedule.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Infrastructure.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(ScheduleContext context) : base(context)
        {

        }
    }
}
