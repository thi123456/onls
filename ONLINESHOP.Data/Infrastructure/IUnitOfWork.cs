namespace ONLINESHOP.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}