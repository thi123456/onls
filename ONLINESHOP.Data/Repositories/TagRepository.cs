﻿using ONLINESHOP.Data.Infrastructure;
using ONLINESHOP.Model.Models;

namespace ONLINESHOP.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}