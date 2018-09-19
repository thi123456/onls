using ONLINESHOP.Data.Infrastructure;
using ONLINESHOP.Model.Models;

namespace ONLINESHOP.Data.Repositories
{
    public interface IApplicationUserRoleRepository : IRepository<ApplicationUserRole>
    {
    }

    public class ApplicationUserRoleRepository : RepositoryBase<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}