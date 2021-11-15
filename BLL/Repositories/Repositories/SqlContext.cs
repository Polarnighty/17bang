using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class SqlContext<T> : SqlContext where T : BaseEntity
    {

        protected DbSet<T> DbSet;
        protected SqlContext context;

        //public DbSet<T> Entites;

        public SqlContext()
        {
            context = new SqlContext();
            DbSet = context.Set<T>();
        }
    }

    public class SqlContext : DbContext
    {
        //private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";

        public SqlContext() : base("18bang")
        {
            Database.Log = s => Debug.WriteLine(s);
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Article>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
