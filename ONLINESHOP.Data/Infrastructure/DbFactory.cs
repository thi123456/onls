namespace ONLINESHOP.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ONLINESHOPDBCONTEXT dbContext;

        public ONLINESHOPDBCONTEXT Init()
        {
            return dbContext ?? (dbContext = new ONLINESHOPDBCONTEXT());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}