using System.Linq;
using System.Threading.Tasks;
using HorizonEvents.Domain;
using HorizonEvents.Persistence.Context;
using HorizonEvents.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HorizonEvents.Persistence
{
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly HorizonEventsContext _context;

        public SpeakerPersist(HorizonEventsContext context)
        {
            _context = context;
        }

        // Speaker

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                    .Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }
    
            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                    .Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }
    
            query = query.AsNoTracking().OrderBy(s => s.Id)
                         .Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(p => p.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                    .Include(s => s.SpeakerEvents)
                    .ThenInclude(se => se.Event);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id)
                         .Where(e => e.Id == speakerId);

            return await query.FirstOrDefaultAsync();       
        }
    }
}