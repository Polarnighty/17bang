using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using BLL.Entites;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class CategoryService :BaseService
    {
        private CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IList<CategoryModel> GetCategories()
        {
            return mapper.Map<IList<Category>, IList<CategoryModel>>(categoryRepository.GetCategories());
        }
    }
}
