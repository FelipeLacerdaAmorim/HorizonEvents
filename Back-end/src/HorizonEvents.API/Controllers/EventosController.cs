using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorizonEvents.Domain;
using HorizonEvents.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HorizonEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventosController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _events = await eventService.GetAllEventsAsync(true);
                if(_events == null)
                {
                    return NotFound("Events not found");
                }
                return Ok(_events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var _event = await eventService.GetEventByIdAsync(id, true);
                if(_event == null)
                {
                    return NotFound("Event not found");
                }
                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var _events = await eventService.GetAllEventsByThemeAsync(theme, true);
                if(_events == null)
                {
                    return NotFound("Events not found");
                }
                return Ok(_events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var _event = await eventService.AddEvent(model);
                if(_event == null)
                {
                    return BadRequest("Event could not be registred");
                }
                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var _event = await eventService.UpdateEvent(id, model);
                if(_event == null)
                {
                    return BadRequest("Event could not be updated");
                }
                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await eventService.DeleteEvent(id))
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Event could not be deleted");
                }
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
    }
}
