using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;
using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
    
        public List<MovieViewModel> GetAll()
        {
            var items = _movieRepository.GetAll().Select(x => x.ToViewModel()).ToList();
            return items;
        }

        public MovieViewModel GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if(movie == null)
            {
                throw new Exception($"Movie with Id: {id} not found!");
            }
            return movie.ToViewModel();
        }

        public MovieViewModel GetByGenre(string genre)
        {
            var movieByGenre = _movieRepository.GetByGenre(genre);

            if( movieByGenre == null)
            {
                throw new Exception($"Movie with Genre:{genre} not found!");
            }

            return movieByGenre.ToViewModel();
        }

        public void Create(MovieViewModel movie)
        {
            //if(string.IsNullOrWhiteSpace(movie.Title))
            //{
            //  throw new Exception("All fields are required");
            //}

            //return _movieRepository.Add(MovieMapper.ToViewModel(movie);
            throw new NotImplementedException();
        }

        public void Delete(int id)
        { 
            if(id == null)
            {
                throw new Exception("There is no movie with this Id");
            }

            _movieRepository.DeleteById(id);
        }
    }
}
