using AutoMapper;
using HorizonEvents.Application.Dtos;
using HorizonEvents.Domain;

namespace HorizonEvents.Application.Helpers
{
    public class HorizonEventsProfile : Profile
    {
        public HorizonEventsProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Speaker, SpeakerDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Batch, BatchDto>().ReverseMap();

        }
    }
}