using MovieApp.Domain;
using MovieApp.Domain.Enums;
using MovieApp.InterfaceModels;

namespace MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToViewModel(this Movie movie)
        {
            return new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
        public static Movie ToModel(this MovieDto movie)
        {
            return new Movie
            {

                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };

        }
    }
}
