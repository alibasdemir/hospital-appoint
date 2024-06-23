using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence.Contexts
{
    public class HospitalAppointDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SystemStat> SystemStats { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EGAQF63\\SQLEXPRESS;Initial Catalog=Database4.Hospital-Appoint;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove cascade delete convention for one-to-many relationships
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configure table names for each entity in the database
            modelBuilder.Entity<User>().ToTable("BaseUsers");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());



            base.OnModelCreating(modelBuilder);
        }
    }
}
