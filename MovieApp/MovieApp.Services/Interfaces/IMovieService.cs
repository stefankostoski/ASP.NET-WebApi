using MovieApp.InterfaceModels;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        List<Movie> GetByGenre(string genre);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
