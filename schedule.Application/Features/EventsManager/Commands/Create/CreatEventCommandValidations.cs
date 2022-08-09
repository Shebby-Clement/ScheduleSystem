using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Create
{
    public class CreatEventCommandValidations : AbstractValidator<CreatEventCommand>
    {
        public CreatEventCommandValidations()
        {

            // I have tried to put little number of properties here
            // mutiple validation rules can still be applied here

            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();

        }
    }
}
