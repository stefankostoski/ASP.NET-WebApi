using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetByGenre(string genre)
        {
            return _dbContext.Movies.FirstOrDefault(g => g.Genre.Equals(genre));
        }

        public void Add(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Movie entity)
        {
           var movie = GetById(entity.Id);

            if(movie != null)
            {
                _dbContext.Movies.Update(entity);
                _dbContext.SaveChanges();
            }

        }
        public void DeleteById(int id)
        {
            var movie = GetById(id);

            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }
}
