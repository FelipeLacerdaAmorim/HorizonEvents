using System.Threading.Tasks;
using HorizonEvents.Application.Dtos;

namespace HorizonEvents.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> AddEvent(EventDto model);
        Task<EventDto> UpdateEvent(int eventId, EventDto model);
        Task<bool> DeleteEvent(int eventId);

        Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers);
        Task<EventDto> GetEventByIdAsync(int eventId, bool includeSpeakers);
    }
}