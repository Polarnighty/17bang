using System;
using System.Collections.Generic;
using BLL.Repositories;
using System.Text;
using BLL.Entites;

namespace DbFactory
{
    public class CategoryFactory
    {
        private CategoryRepository categoryRepository;

        public CategoryFactory(SqlContext context)
        {
            categoryRepository = new CategoryRepository(context);
        }

        public void Create()
        {
            categoryRepository.Save(new Category { Title = "默认分类", Summary = "系统自动生成的默认分类" });
        }
    }
}
