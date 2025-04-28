using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence;
internal class ClassroomsDbContext(DbContextOptions<ClassroomsDbContext> option)
: IdentityDbContext<User>(option)
{
    internal DbSet<Classroom> Classrooms { get; set; }
    internal DbSet<ClassroomEnrollment> ClassroomEnrollments { get; set; }
    internal DbSet<StudentAttendance> StudentAttendances { get; set; }
    internal DbSet<StudentProfile> StudentProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Classroom>()
            .HasOne(c => c.Owner)
            .WithMany(u => u.OwnedClassroom)
            .HasForeignKey(c => c.OwnerId);

        modelBuilder.Entity<ClassroomEnrollment>()
            .HasKey(e => new { e.StudentId, e.ClassroomId });

        modelBuilder.Entity<ClassroomEnrollment>()
            .HasOne(e => e.Student)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<ClassroomEnrollment>()
            .HasOne(e => e.Classroom)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.ClassroomId);

        modelBuilder.Entity<StudentAttendance>()
            .HasOne(a => a.Student)
            .WithMany(b => b.StudentAttendances)
            .HasForeignKey(c => c.StudentId)
            .HasPrincipalKey(d => d.Id);

        modelBuilder.Entity<StudentAttendance>()
           .HasOne(a => a.Classroom)
            .WithMany(c => c.StudentAttendances)
            .HasForeignKey(a => a.ClassroomId);
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.StudentProfile)
            .WithOne(sp => sp.User)
            .HasForeignKey<StudentProfile>(sp => sp.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.TeacherProfile)
            .WithOne(tp => tp.User)
            .HasForeignKey<TeacherProfile>(tp => tp.UserId);
    }
}