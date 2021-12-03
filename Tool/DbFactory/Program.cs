using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Repositories; 

namespace DbFactory
{
    class Program
    {
        private SqlContext context { get; set; }
        static void Main(string[] args)
        {
            new Program().Init();
            //new Program().Initialize();

        }
        void Init()
        {
            
            context = new SqlContext();
            var database = context.Database;
            database.Delete();
            database.Create();

            new UserFactory(context).Create();
            new ArticleFactory(context).Create();
            new MessageFactory(context).Create();
            new CommentFactory(context).Create();

            database.Connection.Dispose();
        }
    }


}
