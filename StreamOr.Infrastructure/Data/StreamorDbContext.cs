using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StreamOr.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace StreamOr.Infrastructure.Data
{
    public class StreamorDbContext : IdentityDbContext
    {
        public StreamorDbContext(DbContextOptions<StreamorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Radio> Radios { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Group>()
                .HasData(
                new Group()
                {
                    Id = 1,
                    Name = "Rock & Metal"
                },
                new Group()
                {
                    Id = 2,
                    Name = "Rap & Soul"
                },
                new Group()
                {
                    Id = 3,
                    Name = "Electronic"
                },
                new Group()
                {
                    Id = 4,
                    Name = "Reggie & Ragga"
                },
                new Group()
                {
                    Id = 5,
                    Name = "Jazz"
                },
                new Group()
                {
                    Id = 6,
                    Name = "Ambient & Chillout"
                },
                new Group()
                {
                    Id = 7,
                    Name = "Retro"
                },
                new Group()
                {
                    Id = 8,
                    Name = "Chrismas"
                },
                new Group()
                {
                    Id = 9,
                    Name = "Pop"
                },
                new Group()
                {
                    Id = 10,
                    Name = "News & Talk"
                },
                new Group()
                {
                    Id = 11,
                    Name = "Religion"
                }
                );

            base.OnModelCreating(builder);
        }
    }
}
