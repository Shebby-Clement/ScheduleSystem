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

namespace schedule.Application.Features.EventsManager.Commands.Create
{
    public class CreatEventCommandHandler : ICommandHandler<CreatEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatEventCommandHandler> _logger;
        public CreatEventCommandHandler(IEventRepository eventRepository, IMapper mapper, ILogger<CreatEventCommandHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(CreatEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventModel = _mapper.Map<Event>(request);

                var result = await _eventRepository.AddAsync(eventModel);

                _logger.LogInformation($"Creating event");

                return result.Id != 0;

            }
            catch (Exception er)
            {
                _logger.LogError($"Exception occured while creating ebent. error: {er.Message}");

                throw new Exception($"{er.Message}");
            }
        }
    }
}
