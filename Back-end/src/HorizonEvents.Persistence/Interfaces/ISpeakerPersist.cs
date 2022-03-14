using System.Threading.Tasks;
using HorizonEvents.Domain;

namespace HorizonEvents.Persistence.Interfaces
{
    public interface ISpeakerPersist
    {
        //Speaker
        Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
    }
}