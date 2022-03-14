using System.Linq;
using System.Threading.Tasks;
using HorizonEvents.Domain;
using HorizonEvents.Persistence.Context;
using HorizonEvents.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HorizonEvents.Persistence
{
    public class EventPersist : IEventPersist
    {
        private readonly HorizonEventsContext _context;

        public EventPersist(HorizonEventsContext context)
        {
            _context = context;
        }

        //Events
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);
            
            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }
    
            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);
            
            if (includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }
    
            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Event> GetEventByIdAsync(int eventId, bool includeEvents = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                    .Include(e => e.SpeakerEvents)
                    .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}