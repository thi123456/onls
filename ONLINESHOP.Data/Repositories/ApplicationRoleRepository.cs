﻿using ONLINESHOP.Data.Infrastructure;
using ONLINESHOP.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ONLINESHOP.Data.Repositories
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
        IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId);
    }

    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId)
        {
            var query = from g in DbContext.ApplicationRoles
                        join ug in DbContext.ApplicationRoleGroups
                        on g.Id equals ug.RoleId
                        where ug.GroupId == groupId
                        select g;
            return query;
        }
    }
}