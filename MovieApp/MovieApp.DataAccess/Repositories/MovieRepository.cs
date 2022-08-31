using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain;

namespace MovieApp.DataAccess.Repositories
{
    public class MovieRepository : IRepository<MovieDto>
    {
        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MovieDto> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public MovieDto GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<MovieDto> GetByGenre(string genre)
        {
            return _dbContext.Movies.Where(x => x.Genre.ToString() == genre).ToList();
        }

        public void Add(MovieDto entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(MovieDto entity)
        {
            var movie = GetById(entity.Id);

            if (movie != null)
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
