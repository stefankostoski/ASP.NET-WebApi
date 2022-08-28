using MovieApp.ViewModels;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAll();
        MovieViewModel GetById(int id);
        MovieViewModel GetByGenre(string genre);
        void Create(MovieViewModel movie);
        void Update(MovieViewModel movie);
        void Delete(int id);
    }
}
