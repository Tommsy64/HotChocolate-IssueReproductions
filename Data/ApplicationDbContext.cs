using Microsoft.EntityFrameworkCore;

namespace HotChocolateIssueReproduction.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Speaker> Speakers { get; init; }
    public DbSet<Location> Locations { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Speaker>().HasData(
            new Speaker
            {
                Id = 1,
                Name = "Jane Doe",
                Bio = "Jane is an expert in GraphQL and .NET technologies.",
                Website = "https://janedoe.dev"
            },
            new Speaker
            {
                Id = 2,
                Name = "John Smith",
                Bio = "John has been working with EF Core since its inception.",
                Website = "https://johnsmith.tech"
            },
            new Speaker
            {
                Id = 3,
                Name = "Alice Johnson",
                Bio = "Alice specializes in Hot Chocolate GraphQL implementations.",
                Website = "https://alicecodes.io"
            }
        );

        builder.Entity<Location>().HasData(
            new Location { Id = 1, Name2 = "San Francisco" },
            new Location { Id = 2, Name2 = "New York" },
            new Location { Id = 3, Name2 = "London" },
            new Location { Id = 4, Name2 = "Berlin" },
            new Location { Id = 5, Name2 = "Tokyo" }
        );

        builder.Entity<Speaker>()
            .HasMany(s => s.Locations)
            .WithMany()
            .UsingEntity(j =>
            {
                j.HasData(
                    new { SpeakerId = 1, LocationsId = 1 },
                    new { SpeakerId = 1, LocationsId = 2 },
                    new { SpeakerId = 2, LocationsId = 2 },
                    new { SpeakerId = 2, LocationsId = 3 },
                    new { SpeakerId = 3, LocationsId = 4 },
                    new { SpeakerId = 3, LocationsId = 5 }
                );
            });
    }
}