using System.Threading.Tasks;
using HorizonEvents.Domain;

namespace HorizonEvents.Persistence.Interfaces
{
    public interface IEventPersist
    {
        //Events
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers);
    }
}