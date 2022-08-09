using schedule.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Delete
{
    public class DeleteEventCommand : ICommand<bool>
    {
        public long id { get; set; }
    }
}
