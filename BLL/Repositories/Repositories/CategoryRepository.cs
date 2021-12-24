using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(SqlContext context) : base(context)
        {
        }

        public IList<Category> GetCategories()
        {
            return DbSet.ToList();
        }
    }
}
