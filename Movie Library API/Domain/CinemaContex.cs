using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movie_Library_API.Domain.Entities;

namespace Movie_Library_API.Domain
{
    public class CinemaContex:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-PFGV5N8DK24;Database=Education;Trusted_Connection=True;");
        }

    }
}
