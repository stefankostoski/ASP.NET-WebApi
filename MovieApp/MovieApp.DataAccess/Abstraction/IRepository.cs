namespace MovieApp.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> GetByGenre(string genre);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
