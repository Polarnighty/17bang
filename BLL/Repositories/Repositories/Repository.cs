using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class Repository<T> where T : BaseEntity, new()
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
            return DbSet.Where(p=>p.Id==Id).SingleOrDefault();
        }

        public int? Save(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }
        public void RangeSave(IList<T> entities)
        {
            DbSet.AddRange(entities);
            context.SaveChanges();
        }
        public T LoadProxy(int id)
        {
            var entity = new T { Id = id };
            DbSet.Attach(entity);
            return entity;
        }
        public void RangeRemove(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                var entity = new T { Id = id[i] };
                DbSet.Remove(DbSet.Attach(entity));
            }
            context.SaveChanges();
        }

    }
}
