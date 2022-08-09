using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Update
{
    public class AcceptOrRejectEventCommandValidations : AbstractValidator<AcceptOrRejectEventCommand>
    {
        public AcceptOrRejectEventCommandValidations()
        {

            // I have tried to put little number of properties here
            // mutiple validation rules can still be applied here

            RuleFor(x => x.AttendeeId).NotEqual(0);
            RuleFor(x => x.EventId).NotEqual(0);
            RuleFor(x => x.IsAttending).NotEmpty();
        }
    }
}

