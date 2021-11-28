using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entites;
using Global;

namespace DbFactory
{
    class ArticleFactory 
    {
        private ArticleRepository articleRepository;
        public ArticleFactory (SqlContext context)
        {
            articleRepository = new ArticleRepository(context);
        }
        public void Create()
        {
            var articles = new List<Article>();
            var sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                sb.Append($@"你好，这是第{i}条测试数据\n");
                articles.Add(new Article
                {
                    Title = $"测试数据{i + 1}",
                    Author = UserFactory.fg,
                    Body = sb.ToString(),
                    Summary = $"你好，这是第{i}条测试数据",
                    PublishDateTime = DateTime.Now.AddDays(-i)
                });
            }
            articleRepository.RangeSave(articles);
        }
    }
}
