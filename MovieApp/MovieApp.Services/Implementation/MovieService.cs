using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain;
using MovieApp.InterfaceModels;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;

        public MovieService(IRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll()
        {
            var items = _movieRepository.GetAll().Select(x => x.ToModel()).ToList();
            return items;
        }

        public Movie GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception($"Movie with Id: {id} not found!");
            }
            return movie.ToModel();
        }

        public List<Movie> GetByGenre(string genre)
        {
            List<Movie> items = _movieRepository.GetAll().Select(x => x.ToModel()).Where(g => g.Genre.ToString() == genre).ToList();
            return items;
        }

        public void Create(Movie movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new Exception("All fields are required");
            }

            _movieRepository.Add(MovieMapper.ToViewModel(movie));
        }

        public void Update(Movie movie)
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
