using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tech2Gether_api.Data;

public class T2TContext : DbContext
{
    // Constructor
    public T2TContext(DbContextOptions<T2TContext> options)
            : base(options)
    {
    }

    // DbSet properties for each table
    public DbSet<MembershipDef> MembershipDefs { get; set; }
    public DbSet<EventDef> EventDefs { get; set; }
    public DbSet<EventSource> EventSources { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<UserOrg> UserOrgs { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<SpeakerMeeting> SpeakerMeetings { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<UserTeam> UserTeams { get; set; }
    public DbSet<EventTeam> EventTeams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // MembershipDef configuration
        modelBuilder.Entity<MembershipDef>(entity =>
        {
            entity.ToTable("membership_def");
            entity.HasKey(e => e.MemId);
            entity.Property(e => e.MemId).HasColumnName("mem_id");
            entity.Property(e => e.MemDesc).HasColumnName("mem_desc").HasMaxLength(20);
            entity.Property(e => e.Active).HasColumnName("active");
        });

        // EventDef configuration
        modelBuilder.Entity<EventDef>(entity =>
        {
            entity.ToTable("event_def");
            entity.HasKey(e => e.EventTypeId);
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.EventTypeDesc).HasColumnName("event_type_desc").HasMaxLength(25);
            entity.Property(e => e.Active).HasColumnName("active");
        });

        // EventSource configuration
        modelBuilder.Entity<EventSource>(entity =>
        {
            entity.ToTable("event_source");
            entity.HasKey(e => e.EventSourceId);
            entity.Property(e => e.EventSourceId).HasColumnName("event_source_id");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.EventName).HasColumnName("event_name").HasMaxLength(60);

            entity.HasOne(e => e.EventDef)
                .WithMany(ed => ed.EventSources)
                .HasForeignKey(e => e.EventTypeId);
        });

        // User configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(25);
            entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(50);
            entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100);
            entity.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(12);
            entity.Property(e => e.MemId).HasColumnName("mem_id");
            entity.Property(e => e.EmFirstName).HasColumnName("em_first_name").HasMaxLength(25);
            entity.Property(e => e.EmLastName).HasColumnName("em_last_name").HasMaxLength(50);
            entity.Property(e => e.EmRelationship).HasColumnName("em_relationship").HasMaxLength(40);
            entity.Property(e => e.EmPhone).HasColumnName("em_phone").HasMaxLength(12);
            entity.Property(e => e.UserGithub).HasColumnName("user_github").HasMaxLength(200);
            entity.Property(e => e.UserLinkedin).HasColumnName("user_linkedin").HasMaxLength(200);
            entity.Property(e => e.Pronouns).HasColumnName("pronouns").HasMaxLength(20);
            entity.Property(e => e.PreName).HasColumnName("pre_name").HasMaxLength(20);

            entity.HasOne(e => e.MembershipDef)
                .WithMany(m => m.Users)
                .HasForeignKey(e => e.MemId);

            entity.HasIndex(e => e.MemId).HasDatabaseName("idx_user_mem_id");
        });

        // Address configuration
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("address");
            entity.HasKey(e => e.AddressId);
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Street1).HasColumnName("street_1").HasMaxLength(50);
            entity.Property(e => e.Street2).HasColumnName("street_2").HasMaxLength(20);
            entity.Property(e => e.City).HasColumnName("city").HasMaxLength(50);
            entity.Property(e => e.State).HasColumnName("state").HasMaxLength(2);
            entity.Property(e => e.Zip).HasColumnName("zip").HasMaxLength(5);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(e => e.UserId);

            entity.HasIndex(e => e.UserId).HasDatabaseName("idx_address_user_id");
        });

        // Organization configuration
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.ToTable("organization");
            entity.HasKey(e => e.OrgId);
            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.OrgName).HasColumnName("org_name").HasMaxLength(100);
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.OrgPhone).HasColumnName("org_phone").HasMaxLength(12);
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.OrgEmail).HasColumnName("org_email").HasMaxLength(100);

            entity.HasOne(e => e.Address)
                .WithMany()
                .HasForeignKey(e => e.AddressId);

            entity.HasIndex(e => e.AddressId).HasDatabaseName("idx_organization_address_id");
        });

        // UserOrg configuration
        modelBuilder.Entity<UserOrg>(entity =>
        {
            entity.ToTable("user_org");
            entity.HasKey(e => e.UserOrgId);
            entity.Property(e => e.UserOrgId).HasColumnName("user_org_id");
            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.GraduationDate).HasColumnName("graduation_date");

            entity.HasOne(e => e.Organization)
                .WithMany(o => o.UserOrgs)
                .HasForeignKey(e => e.OrgId);

            entity.HasOne(e => e.User)
                .WithMany(u => u.UserOrgs)
                .HasForeignKey(e => e.UserId);

            entity.HasIndex(e => e.OrgId).HasDatabaseName("idx_user_org_org_id");
            entity.HasIndex(e => e.UserId).HasDatabaseName("idx_user_org_user_id");
        });

        // Login configuration
        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("login");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(64);
            entity.Property(e => e.PasswordSalt).HasColumnName("password_salt").HasMaxLength(16);
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.EmailVerificationToken).HasColumnName("email_verification_token").HasMaxLength(64);
            entity.Property(e => e.EmailVerificationExpires).HasColumnName("email_verification_expires");
            entity.Property(e => e.EmailIsVerified).HasColumnName("email_is_verified").HasDefaultValue(false);
            entity.Property(e => e.PasswordResetToken).HasColumnName("password_reset_token").HasMaxLength(64);
            entity.Property(e => e.PasswordResetExpires).HasColumnName("password_reset_expires");

            entity.HasOne(e => e.User)
                .WithOne(u => u.Login)
                .HasForeignKey<Login>(e => e.UserId);
        });

        // Meeting configuration
        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.ToTable("meeting");
            entity.HasKey(e => e.MeetingId);
            entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
            entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(100);
            entity.Property(e => e.MeetingDate).HasColumnName("meeting_date");
        });

        // Speaker configuration
        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.ToTable("speaker");
            entity.HasKey(e => e.SpeakerId);
            entity.Property(e => e.SpeakerId).HasColumnName("speaker_id");
            entity.Property(e => e.SpeakerFirstName).HasColumnName("speaker_first_name").HasMaxLength(25);
            entity.Property(e => e.SpeakerLastName).HasColumnName("speaker_last_name").HasMaxLength(50);
            entity.Property(e => e.SpeakerLinkedin).HasColumnName("speaker_linkedin").HasMaxLength(200);
            entity.Property(e => e.SpeakerOrganization).HasColumnName("speaker_organization");
            entity.Property(e => e.SpeakerTitle).HasColumnName("speaker_title").HasMaxLength(60);

            entity.HasOne(e => e.Organization)
                .WithMany()
                .HasForeignKey(e => e.SpeakerOrganization);
        });

        // SpeakerMeeting configuration
        modelBuilder.Entity<SpeakerMeeting>(entity =>
        {
            entity.ToTable("speaker_meeting");
            entity.HasKey(e => e.SpeakerMeetingId);
            entity.Property(e => e.SpeakerMeetingId).HasColumnName("speaker_meeting_id");
            entity.Property(e => e.SpeakerId).HasColumnName("speaker_id");
            entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

            entity.HasOne(e => e.Speaker)
                .WithMany(s => s.SpeakerMeetings)
                .HasForeignKey(e => e.SpeakerId);

            entity.HasOne(e => e.Meeting)
                .WithMany(m => m.SpeakerMeetings)
                .HasForeignKey(e => e.MeetingId);
        });

        // Attendance configuration
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("attendance");
            entity.HasKey(e => e.AttendanceId);
            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

            entity.HasOne(e => e.User)
                .WithMany(u => u.Attendances)
                .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.Meeting)
                .WithMany(m => m.Attendances)
                .HasForeignKey(e => e.MeetingId);

            entity.HasIndex(e => e.UserId).HasDatabaseName("idx_attendance_user_id");
            entity.HasIndex(e => e.MeetingId).HasDatabaseName("idx_attendance_meeting_id");
        });

        // Event configuration
        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("event");
            entity.HasKey(e => e.EventId);
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventSourceId).HasColumnName("event_source_id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventEndDate).HasColumnName("event_end_date");

            entity.HasOne(e => e.EventSource)
                .WithMany(es => es.Events)
                .HasForeignKey(e => e.EventSourceId);

            entity.HasIndex(e => e.EventSourceId).HasDatabaseName("idx_event_source_id");
        });

        // EventTeam configuration
        modelBuilder.Entity<EventTeam>(entity =>
        {
            entity.ToTable("event_team");
            entity.HasKey(e => e.TeamId);
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.UserTeamId).HasColumnName("user_team_id");
            entity.Property(e => e.TeamName).HasColumnName("team_name").HasMaxLength(40);

            entity.HasOne(e => e.Event)
                .WithMany(ev => ev.EventTeams)
                .HasForeignKey(e => e.EventId);

            entity.HasOne(e => e.UserTeam)
                .WithMany()
                .HasForeignKey(e => e.UserTeamId);
        });

        // UserTeam configuration
        modelBuilder.Entity<UserTeam>(entity =>
        {
            entity.ToTable("user_team");
            entity.HasKey(e => e.UserTeamId);
            entity.Property(e => e.UserTeamId).HasColumnName("user_team_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Leader).HasColumnName("leader");

            entity.HasOne(e => e.EventTeam)
                .WithMany(et => et.UserTeams)
                .HasForeignKey(e => e.TeamId);

            entity.HasOne(e => e.User)
                .WithMany(u => u.UserTeams)
                .HasForeignKey(e => e.UserId);
        });
    }
}