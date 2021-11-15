using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class Repository<T> where T: BaseEntity ,new()
    {
        protected DbSet<T> DbSet;
        protected SqlContext context;


        public Repository(SqlContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }
        public T Find(int Id)
        {
            //return context.Entites.Find(Id);
            return DbSet.Find(Id);
        }

        public int Save(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }
        public T LoadProxy(int id)
        {
            var entity = new T { Id = id };
            DbSet.Attach(entity);
            return entity;
        }
        public void Remove(T entity)
        {
        }
    }
}
