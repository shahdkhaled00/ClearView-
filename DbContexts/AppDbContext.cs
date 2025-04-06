using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ClearView.Models;
namespace ClearView.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<VisionTest> VisionTests { get; set; }
    public DbSet<DiseaseDetection> DiseaseDetections { get; set; }
    public DbSet<ChatbotInteraction> ChatbotInteractions { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //  Use Constraints
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        

    modelBuilder.Entity<User>()
        .HasDiscriminator<string>("Discriminator")
        .HasValue<Doctor>("Doctor")
        .HasValue<User>("Patient"); 


        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(10000);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Age)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Gender)
            .IsRequired();
        
        // Relationships - Lookup Tables
        modelBuilder.Entity<User>()
            .HasOne(u => u.City)
            .WithMany()
            .HasForeignKey(u => u.CityId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId);

 ;

        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Clinic)
            .WithMany()
            .HasForeignKey(d => d.ClinicId);

        //  Doctor as a Subclass of User
        modelBuilder.Entity<Doctor>()
            .HasBaseType<User>();

        // Relationships - One-to-Many
       modelBuilder.Entity<Appointment>()
        .HasOne(a => a.User)
        .WithMany(u => u.Appointments)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict);

       modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Doctor)
        .WithMany()
        .HasForeignKey(a => a.DoctorId)
        .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<User>()
        .HasOne(u => u.AssignedDoctor) 
        .WithMany(d => d.Patients) 
        .HasForeignKey(u => u.DoctorId)
        .OnDelete(DeleteBehavior.Restrict); 

       
        modelBuilder.Entity<VisionTest>()
            .HasOne(v => v.User)
            .WithMany(u => u.VisionTests)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DiseaseDetection>()
            .HasOne(d => d.User)
            .WithMany(u => u.DiseaseDetections)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChatbotInteraction>()
            .HasOne(c => c.User)
            .WithMany(u => u.ChatbotInteractions)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
