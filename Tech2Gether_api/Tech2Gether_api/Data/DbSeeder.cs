using Microsoft.EntityFrameworkCore;
using Tech2Gether_api.Data;

namespace ClubWebsite.Data
{
    public class DbSeeder
    {
        private readonly T2TContext _context;
        
        public DbSeeder(T2TContext context)
        {
            _context = context;
        }
        
        public async Task SeedAsync()
        {
            Console.WriteLine("Checking database state...");
            
            // Check if we already have data
            if (await _context.MembershipDefs.AnyAsync())
            {
                Console.WriteLine("Database already has data. Skipping seed.");
                Console.WriteLine("To re-seed, first drop the database with: dotnet ef database drop --force");
                return;
            }
            
            Console.WriteLine("Starting database seed...");
            
            // Seed in order of dependencies
            await SeedMembershipDefinitions();
            await SeedEventDefinitions();
            await SeedEventSources();
            await SeedEvents();
            await SeedSampleUser();
            
            Console.WriteLine("\n✓ Database seeded successfully!");
            Console.WriteLine("\nSample Login Credentials:");
            Console.WriteLine("  Email: tech2gether@otc.edu");
            Console.WriteLine("  Password: DevPassword123! (if using authentication)");
        }
        
        private async Task SeedMembershipDefinitions()
        {
            var membershipTypes = new[]
            {
                new MembershipDef { MemDesc = "Officer", Active = true },
                new MembershipDef { MemDesc = "Active Member", Active = true },
                new MembershipDef { MemDesc = "Participating Member", Active = true },
                new MembershipDef { MemDesc = "Alumni", Active = true },
                new MembershipDef { MemDesc = "Competitor", Active = true },
                new MembershipDef { MemDesc = "Faculty", Active = true },
                new MembershipDef { MemDesc = "Sponsor", Active = true }
            };
            
            await _context.MembershipDefs.AddRangeAsync(membershipTypes);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✓ Seeded {membershipTypes.Length} membership definitions");
        }
        
        private async Task SeedEventDefinitions()
        {
            var eventTypes = new[]
            {
                new EventDef { EventTypeDesc = "Hackathon", Active = true },
                new EventDef { EventTypeDesc = "Capture the Flag", Active = true }
            };
            
            await _context.EventDefs.AddRangeAsync(eventTypes);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✓ Seeded {eventTypes.Length} event type definitions");
        }
        
        private async Task SeedEventSources()
        {
            // Get the event type IDs that were just created
            var hackathonType = await _context.EventDefs
                .FirstOrDefaultAsync(e => e.EventTypeDesc == "Hackathon");
            var ctfType = await _context.EventDefs
                .FirstOrDefaultAsync(e => e.EventTypeDesc == "Capture the Flag");
            
            if (hackathonType == null || ctfType == null)
            {
                throw new Exception("Event definitions not found. Cannot seed event sources.");
            }
            
            var eventSources = new[]
            {
                new EventSource 
                { 
                    EventTypeId = hackathonType.EventTypeId,
                    EventName = "Hack2Gether"
                },
                new EventSource 
                { 
                    EventTypeId = ctfType.EventTypeId,
                    EventName = "Ozzy's Cyber Heist"
                }
            };
            
            await _context.EventSources.AddRangeAsync(eventSources);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✓ Seeded {eventSources.Length} event sources");
        }
        
        private async Task SeedEvents()
        {
            // Get the event sources
            var hack2gether = await _context.EventSources
                .FirstOrDefaultAsync(e => e.EventName == "Hack2Gether");
            var ozzyCyberHeist = await _context.EventSources
                .FirstOrDefaultAsync(e => e.EventName == "Ozzy's Cyber Heist");
            
            if (hack2gether == null || ozzyCyberHeist == null)
            {
                throw new Exception("Event sources not found. Cannot seed events.");
            }
            
            var events = new[]
            {
                new Event
                {
                    EventSourceId = hack2gether.EventSourceId,
                    EventDate = new DateTime(2026, 3, 26),
                    EventEndDate = new DateTime(2026, 3, 28)
                },
                new Event
                {
                    EventSourceId = ozzyCyberHeist.EventSourceId,
                    EventDate = new DateTime(2025, 11, 17),
                    EventEndDate = new DateTime(2025, 11, 17)
                }
            };
            
            await _context.Events.AddRangeAsync(events);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✓ Seeded {events.Length} events");
        }
        
        private async Task SeedSampleUser()
        {
            // Get the Officer membership type
            var officerMembership = await _context.MembershipDefs
                .FirstOrDefaultAsync(m => m.MemDesc == "Officer");
            
            if (officerMembership == null)
            {
                throw new Exception("Officer membership type not found. Cannot seed users.");
            }
            
            var sampleUser = new User
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "tech2gether@otc.edu",
                Phone = "1234567891",
                MemId = officerMembership.MemId,
                EmFirstName = "Jane",
                EmLastName = "Smith",
                EmRelationship = "Mother",
                EmPhone = "0987654321",
                Pronouns = "He/Him"
            };
            
            await _context.Users.AddAsync(sampleUser);
            await _context.SaveChangesAsync();
            Console.WriteLine($"✓ Seeded 1 sample user (Officer)");
        }
    }
}