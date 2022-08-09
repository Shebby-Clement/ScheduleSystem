using AutoMapper;
using schedule.Application.Features.EventsManager.Commands.Create;
using schedule.Application.Features.EventsManager.Commands.Update;
using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Mappings
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<UpdateEventCommand, Event>().ReverseMap();
            CreateMap<CreatEventCommand, Event>().ReverseMap();
        }
    }
}
