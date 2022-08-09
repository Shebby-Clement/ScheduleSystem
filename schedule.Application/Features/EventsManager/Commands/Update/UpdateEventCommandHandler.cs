using AutoMapper;
using Microsoft.Extensions.Logging;
using schedule.Application.Contracts.Persistence;
using schedule.Application.Messaging;
using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Update
{

    public class UpdateEventCommandHandler : ICommandHandler<UpdateEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEventCommandHandler> _logger;
        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, ILogger<UpdateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var eventModel = _mapper.Map<Event>(request);

                await _eventRepository.UpdateAsync(eventModel);

                _logger.LogInformation($"updating event");

                return true;

            }
            catch (Exception er)
            {
                _logger.LogError($"Exception occured while creating ebent. error: {er.Message}");

                throw new Exception($"{er.Message}");
            }
        }
    }
}
