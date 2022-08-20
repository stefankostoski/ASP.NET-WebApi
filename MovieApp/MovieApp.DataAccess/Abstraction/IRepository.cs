namespace MovieApp.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
