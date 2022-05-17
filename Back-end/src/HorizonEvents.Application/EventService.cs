using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HorizonEvents.Application.Dtos;
using HorizonEvents.Application.Interfaces;
using HorizonEvents.Domain;
using HorizonEvents.Persistence.Interfaces;

namespace HorizonEvents.Application
{
    public class EventService : IEventService
    {
        private readonly IEventPersist _eventPersist;
        private readonly IGeneralPersist _generalPersist;

        private readonly IMapper _mapper;

        public EventService(IEventPersist eventPersist, 
                            IGeneralPersist generalPersist,
                            IMapper mapper)
        {
            _generalPersist = generalPersist;
            _eventPersist = eventPersist;
            _mapper = mapper;
        }

        public async Task<EventDto> AddEvent(EventDto model)
        {
            try
            {
                var _event = _mapper.Map<Event>(model);

                _generalPersist.Add<Event>(_event);

                if(await _generalPersist.SaveChangesAsync())
                {
                    var result = await _eventPersist.GetEventByIdAsync(_event.Id, false);
                    return _mapper.Map<EventDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> UpdateEvent(int eventId, EventDto model)
        {
            try
            {
                var _event = await _eventPersist.GetEventByIdAsync(eventId, false);

                if(_event == null) 
                {
                    return null;
                }

                model.Id = _event.Id;

                _mapper.Map(model, _event);

                _generalPersist.Update<Event>(_event);
                
                if(await _generalPersist.SaveChangesAsync())
                {
                    var result = await _eventPersist.GetEventByIdAsync(model.Id, false);
                    return _mapper.Map<EventDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var _event = await _eventPersist.GetEventByIdAsync(eventId, false);

                if(_event == null) 
                {
                    throw new Exception("Event not found.");
                }

                _generalPersist.Delete<Event>(_event);
                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers)
        {
            try{
                var _events = await _eventPersist.GetAllEventsAsync(includeSpeakers);
                if (_events == null)
                {
                    return null;
                }

                var results = _mapper.Map<EventDto[]>(_events);

                return results;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers)
        {

            try{
                var _events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (_events == null)
                {
                    return null;
                }
                
                var results = _mapper.Map<EventDto[]>(_events);

                return results;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int eventId, bool includeSpeakers)
        {

            try{
                var _event = await _eventPersist.GetEventByIdAsync(eventId, includeSpeakers);
                if (_event == null)
                {
                    return null;
                }

                var result = _mapper.Map<EventDto>(_event);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}