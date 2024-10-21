using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
