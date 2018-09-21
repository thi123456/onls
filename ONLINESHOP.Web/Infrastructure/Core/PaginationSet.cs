using System.Collections.Generic;
using System.Linq;

namespace ONLINESHOP.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public IEnumerable<T> Items { get; set; }
    }
}