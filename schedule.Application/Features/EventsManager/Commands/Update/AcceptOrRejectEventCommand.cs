using schedule.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Update
{
    public class AcceptOrRejectEventCommand : ICommand<bool>
    {
        public bool IsAttending { get; set; }
        public long AttendeeId { get; set; }
        public long EventId { get; set; }
    }
}
