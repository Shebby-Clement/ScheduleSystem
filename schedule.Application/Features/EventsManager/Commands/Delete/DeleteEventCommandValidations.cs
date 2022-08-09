using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Delete
{
    public class DeleteEventCommandValidations : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidations()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
