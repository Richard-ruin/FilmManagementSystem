using FilmManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FilmManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }

        // You can add additional DbSets for other models here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can add seed data here if needed
            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Title = "Laskar Pelangi",
                    Director = "Riri Riza",
                    ReleaseYear = 2008,
                    Genre = "Drama",
                    Duration = 125,
                    Description = "Film berdasarkan novel Andrea Hirata tentang perjuangan anak-anak di Belitung untuk mendapatkan pendidikan",
                    DateAdded = DateTime.Now
                },
                new Film
                {
                    Id = 2,
                    Title = "Pengabdi Setan",
                    Director = "Joko Anwar",
                    ReleaseYear = 2017,
                    Genre = "Horror",
                    Duration = 107,
                    Description = "Remake film horor klasik Indonesia dari tahun 1980",
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}