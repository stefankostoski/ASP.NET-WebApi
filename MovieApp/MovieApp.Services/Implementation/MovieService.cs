using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;
using MovieApp.ViewModels;

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
            var items = _movieRepository.GetAll().Select(x => x.ToModel()).ToList();
            return items;
        }

        public MovieViewModel GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception($"Movie with Id: {id} not found!");
            }
            return movie.ToModel();
        }

        public MovieViewModel GetByGenre(string genre)
        {
            var movieByGenre = _movieRepository.GetByGenre(genre);

            if (movieByGenre == null)
            {
                throw new Exception($"Movie with Genre:{genre} not found!");
            }

            return movieByGenre.ToModel();
        }

        public void Create(MovieViewModel movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new Exception("All fields are required");
            }

            _movieRepository.Add(MovieMapper.ToViewModel(movie));
        }

        public void Update(MovieViewModel movie)
        {
            var item = _movieRepository.GetById(movie.Id);
            if (item != null)
            {
                _movieRepository.Update(MovieMapper.ToViewModel(movie));
            }
        }

        public void Delete(int id)
        {
            if (id == null)
            {
                throw new Exception("There is no movie with this Id");
            }

            _movieRepository.DeleteById(id);
        }
    }
}
