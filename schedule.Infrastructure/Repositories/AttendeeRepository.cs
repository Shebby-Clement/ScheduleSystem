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

    public class AttendeeRepository : RepositoryBase<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ScheduleContext context) : base(context)
        {

        }
    }
}
