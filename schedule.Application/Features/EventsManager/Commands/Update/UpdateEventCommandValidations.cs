using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Update
{
    public class UpdateEventCommandValidations : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidations()
        {

            // I have tried to put little number of properties here
            // mutiple validation rules can still be applied here

            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();

        }
    }
}
