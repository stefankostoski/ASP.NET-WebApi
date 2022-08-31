using MoviesApp.DataAccess.Abstraction;
using MoviesApp.DomainModels;

namespace MoviesApp.DataAccess.Repositories
{
    public class MovieRepository : IRepository<MovieDto>
    {
        private readonly MoviesAppDbContext _dbContext;
        public MovieRepository(MoviesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MovieDto> GetAll()
        {
            return _dbContext.Movies.ToList();
        }
        public MovieDto GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<MovieDto> GetByGenre(int genre)
        {
            return _dbContext.Movies.FirstOrDefault(g => g.Genre.Equals(genre));
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
        public void Delete(MovieDto entity)
        {
            var movie = GetById(entity.Id);

            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }
}
