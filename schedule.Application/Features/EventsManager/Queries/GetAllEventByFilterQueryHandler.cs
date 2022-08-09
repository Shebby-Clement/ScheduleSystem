using AutoMapper;
using schedule.Application.Contracts.Persistence;
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
    public class GetAllEventByFilterQueryHandler : IQueryHandler<GetAllEventByFilterQuery, List<Event>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public GetAllEventByFilterQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<Event>> Handle(GetAllEventByFilterQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(request.Filter))
            {
                events = events.Where(x => x.Title.ToLower().Contains(request.Filter.ToLower())
                || x.Description.ToLower().Contains(request.Filter.ToLower())).ToList();
            }

            return (List<Event>)events;
        }

    }
}
