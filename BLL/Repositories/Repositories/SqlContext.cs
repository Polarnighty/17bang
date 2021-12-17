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

        protected DbSet<T> DbSet { get; set; }
        protected SqlContext context;
        public SqlContext()
        {
            context = new SqlContext();
            DbSet = context.Set<T>();
        }
    }

    public class SqlContext : DbContext
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=18bang;Integrated Security=True;";

        public SqlContext() : base(connectionString)
        {
            Database.Log = s => Debug.WriteLine(s);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Message>();
            modelBuilder.Entity<Appraise>();
            modelBuilder.Entity<Comment>();
            modelBuilder.Entity<Profile>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
