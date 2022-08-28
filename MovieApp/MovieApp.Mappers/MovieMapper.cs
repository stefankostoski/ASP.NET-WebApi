using MovieApp.Domain;
using MovieApp.Domain.Enums;
using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToViewModel(this MovieViewModel movie)
        {
            return new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
        public static MovieViewModel ToModel(this Movie movie)
        {
            return new MovieViewModel
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
