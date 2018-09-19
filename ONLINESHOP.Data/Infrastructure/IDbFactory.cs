using System;

namespace ONLINESHOP.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ONLINESHOPDBCONTEXT Init();
    }
}