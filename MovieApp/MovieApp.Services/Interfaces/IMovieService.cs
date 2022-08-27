using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAll();
        MovieViewModel GetById(int id);
        MovieViewModel GetByGenre(string genre);
        void Create (MovieViewModel movie);
        void Delete (int id);
    }
}
