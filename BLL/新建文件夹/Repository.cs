using Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> where T: BaseEntity
    {
        protected DbSet<T> DbSet;
        protected SqlContext context;


        public Repository()
        {
            context = new SqlContext();
            DbSet = context.Set<T>();
        }
        public T Find(int Id)
        {
            //return context.Entites.Find(Id);
            return DbSet.Find(Id);
        }

        public T Save(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public void Remove(T entity)
        {
        }
    }
}
