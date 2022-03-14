using Microsoft.EntityFrameworkCore;
using HorizonEvents.Domain;

namespace HorizonEvents.Persistence.Context
{
    public class HorizonEventsContext : DbContext
    {
        public HorizonEventsContext(DbContextOptions<HorizonEventsContext> options) : base(options){}
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
            .HasKey(SE => new {SE.EventId, SE.SpeakerId});

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialMedias)
                .WithOne(sm => sm.Event)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Speaker>()
                .HasMany(e => e.SocialMedias)
                .WithOne(sm => sm.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}