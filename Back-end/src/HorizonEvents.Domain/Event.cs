using System;
using System.Collections.Generic;

namespace HorizonEvents.Domain
{
    public class Event
    {
        public int Id { get; set;}
        public string Local { get; set; }
        public DateTime EventDate { get; set; }
        public string Theme { get; set; }
        public int NumPeople { get; set; }
        public string ImageURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }

    }
}