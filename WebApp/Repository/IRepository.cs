namespace WebApp.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T? t);
    }
}
