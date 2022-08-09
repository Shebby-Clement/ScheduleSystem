using AutoMapper;
using schedule.Application.Contracts.Persistence;
using schedule.Application.Exceptions;
using schedule.Application.Messaging;
using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace schedule.Application.Features.EventsManager.Queries
{
    public class GetEventByIdQueryHandler : IQueryHandler<GetEventByIdQuery, Event>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventResult = await _eventRepository.GetByIdAsync(request.EventId);

            if (eventResult == null)
            {
                throw new NotFoundException("Event is not found for id: ", request.EventId);
            }

            return eventResult;
        }

    }
}
