using Microsoft.EntityFrameworkCore;
using MoviesApp.DomainModels;

namespace MoviesApp.DataAccess
{
    public class MoviesAppDbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MovieDto> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDto>().HasData(
                new MovieDto
                {
                    Id = 1,
                    Title = "No Time to Die",
                    Description = "Bond has left active service and is enjoying a tranquil life in Jamaica. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help. The mission to rescue a kidnapped scientist turns out to be far more treacherous than expected, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                    Year = 2021,
                    Genre = DomainModels.Enums.Genre.Action
                },
                new MovieDto
                {
                    Id = 2,
                    Title = "American Pie Presents: Beta House",
                    Description = "Erik, and Cooze start college and pledge the Beta House fraternity, presided over by none other than legendary Dwight Stifler. But chaos ensues when a fraternity of geeks threatens to stop the debauchery and the Betas have to make a stand for their right to party.",
                    Year = 2007,
                    Genre = DomainModels.Enums.Genre.Comedy
                },
                new MovieDto
                {
                    Id = 3,
                    Title = "Insidious: Chapter 3",
                    Description = "Quinn, a young girl, reaches out to a powerful psychic to help her contact her recently deceased mother. However, her plan backfires when an evil spirit makes Quinn a host and hurts her physically.",
                    Year = 2015,
                    Genre = DomainModels.Enums.Genre.Horror
                },
                new MovieDto
                {
                    Id = 4,
                    Title = "Gone Girl",
                    Description = "Nick Dunne discovers that the entire media focus has shifted on him when his wife, Amy Dunne, mysteriously disappears on the day of their fifth wedding anniversary.",
                    Year = 2014,
                    Genre = DomainModels.Enums.Genre.Drama
                });
        }
    }
}
