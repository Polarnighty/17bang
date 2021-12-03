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
    class CommentFactory
    {
        private CommentRepository CommentRepository;
        
        public CommentFactory(SqlContext context)
        {
            CommentRepository = new CommentRepository(context);
        }
        public void Create()
        {
            var comments = new List<Comment>();
            var sb = new StringBuilder();
            var date = DateTime.Now.AddDays(-30);
            for (int i = 0; i < 10; i++)
            {
                var comment = new Comment { Article= ArticleFactory.First, CommentTime = date.AddDays(i), Commentator = UserFactory.fg, Content = $"这是评论内容{i + 1}" };
                if (i < 3)
                {
                    comment.CommentBy = new[]  { new Comment { Article= ArticleFactory.First, CommentTime = date.AddDays(i), Commentator = UserFactory.fg, Content = $"这是评论子内容{i+1}:1" },
                        new Comment {  Article= ArticleFactory.First,CommentTime = date.AddDays(i+1), Commentator = UserFactory.fg, Content = $"这是评论子内容{i}:2" },
                    };
                }
                comments.Add(comment);
            }
            CommentRepository.RangeSave(comments);
        }
    }
}
