using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence;
internal class ClassroomsDbContext(DbContextOptions<ClassroomsDbContext> option)
: IdentityDbContext<User>(option)
{
    internal DbSet<Classroom> Classrooms { get; set; }
    internal DbSet<ClassroomEnrollment> ClassroomEnrollments { get; set; }

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
    }
}