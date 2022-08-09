using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using schedule.Application.Features.EventsManager.Commands.Create;
using schedule.Application.Features.EventsManager.Commands.Delete;
using schedule.Application.Features.EventsManager.Commands.Update;
using schedule.Application.Features.EventsManager.Queries;
using schedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace schedule.API.Controllers
{

    [ApiController]
    //[Authorize]
    [Route("/api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventsController> _logger;
        public EventsController(ILogger<EventsController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]", Name = "Get-all-events")]
        [ProducesResponseType(typeof(IEnumerable<Event>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllAsync()
        {
            try
            {
                var events = await _mediator.Send(new GetAllEventByFilterQuery());

                return Ok(events);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }

        [HttpGet]
        [Route("[action]/{filter}", Name = "Get-all-events-by-Filter")]
        [ProducesResponseType(typeof(IEnumerable<Event>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllAsync(string filter = "")
        {
            try
            {
                var events = await _mediator.Send(new GetAllEventByFilterQuery
                {
                    Filter = filter
                });

                return Ok(events);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }

        [HttpGet]
        [Route("[action]/{eventId}", Name = "Get-event-byId")]
        [ProducesResponseType(typeof(Event), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Event>> GetById(long eventId)
        {
            try
            {
                var eventModel = await _mediator.Send(new GetEventByIdQuery { EventId = eventId });

                if (eventModel == null)
                {
                    return NotFound();
                }

                return Ok(eventModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }


        [HttpDelete("{eventId}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateEvent(long eventId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteEventCommand { id = eventId }));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Event), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSms([FromBody] CreatEventCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMultipleSms([FromBody] UpdateEventCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }
    }
}
