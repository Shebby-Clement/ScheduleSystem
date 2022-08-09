using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Contracts.Persistence
{
    public interface IAttendeeRepository : IAsyncRepository<Attendee>
    {
    }
}
