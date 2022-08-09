using AutoMapper;
using Microsoft.Extensions.Logging;
using schedule.Application.Contracts.Persistence;
using schedule.Application.Exceptions;
using schedule.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Commands.Delete
{
    public class DeleteEventCommandHandler : ICommandHandler<DeleteEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteEventCommandHandler> _logger;
        public DeleteEventCommandHandler(ILogger<DeleteEventCommandHandler> logger, IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventModel = await _eventRepository.GetByIdAsync(request.id);

                if (eventModel != null)
                {
                    await _eventRepository.DeleteAsync(eventModel);

                    _logger.LogInformation($"Deleted event with id: {eventModel.Id}");

                    return true;
                }

                throw new NotFoundException("Event", request.id);
            }
            catch (Exception er)
            {
                _logger.LogError($"Error occured deleting event. Error: {er.Message}");

                throw new Exception($"{er.Message}");
            }
        }
    }
}
