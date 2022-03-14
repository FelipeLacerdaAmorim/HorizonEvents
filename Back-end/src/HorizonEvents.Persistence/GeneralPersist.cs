using System.Linq;
using System.Threading.Tasks;
using HorizonEvents.Domain;
using Microsoft.EntityFrameworkCore;
using HorizonEvents.Persistence.Interfaces;
using HorizonEvents.Persistence.Context;

namespace HorizonEvents.Persistence
{
    public class GeneralPersist : IGeneralPersist
    {
        private readonly HorizonEventsContext _context;

        public GeneralPersist(HorizonEventsContext context)
        {
            _context = context;
        }

        // General
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}