using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using BLL.Entites;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class CategoryService : BaseService
    {
        private CategoryRepository categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository(context);
        }

        public IList<CategoryModel> GetCategories()
        {
            return mapper.Map<IList<Category>, IList<CategoryModel>>(categoryRepository.GetCategories());
        }
        public void NewOrEdit(CategoryModel model)
        {
            var category = mapper.Map<CategoryModel, Category>(model);
            categoryRepository.NewOrEdit(category);
        }
        public bool DeleteCategory(int id)
        {
            if (GetCurrentUser().Id != 1)
            {
                return false;
            }
            else
            {
                categoryRepository.DeleteCategory(id);
                return true;
            }
        }


    }
}
