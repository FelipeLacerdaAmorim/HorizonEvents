using System;
using System.Threading.Tasks;
using HorizonEvents.Application.Interfaces;
using HorizonEvents.Domain;
using HorizonEvents.Persistence.Interfaces;

namespace HorizonEvents.Application
{
    public class EventService : IEventService
    {
        private readonly IEventPersist _eventPersist;
        private readonly IGeneralPersist _generalPersist;

        public EventService(IEventPersist eventPersist, IGeneralPersist generalPersist)
        {
            _generalPersist = generalPersist;
            _eventPersist = eventPersist;
        }

        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _generalPersist.Add<Event>(model);
                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var _event = await _eventPersist.GetEventByIdAsync(eventId, false);

                if(_event == null) 
                {
                    return null;
                }

                model.Id = _event.Id;

                _generalPersist.Update<Event>(model);
                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
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


        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers)
        {
            try{
                var _events = await _eventPersist.GetAllEventsAsync(includeSpeakers);
                if (_events == null)
                {
                    return null;
                }
                return _events;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers)
        {

            try{
                var _events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (_events == null)
                {
                    return null;
                }
                return _events;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers)
        {

            try{
                var _event = await _eventPersist.GetEventByIdAsync(eventId, includeSpeakers);
                if (_event == null)
                {
                    return null;
                }
                return _event;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}