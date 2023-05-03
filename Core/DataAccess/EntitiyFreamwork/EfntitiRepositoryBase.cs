using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntitiyFreamwork
{
    public class EfntitiRepositoryBase<TEntitiy,TContext>:IEntitiyRepository<TEntitiy>
        where TEntitiy : class ,IEntity,
        new() where TContext : DbContext,new()
    {
        public void add(TEntitiy entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntitiy = context.Entry(entity);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void delete(TEntitiy entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntitiy = context.Entry(entity);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

      
        public TEntitiy Get(Expression<Func<TEntitiy, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntitiy>().FirstOrDefault(filter);
            }
        }

        public List<TEntitiy> GetAll(Expression<Func<TEntitiy, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntitiy>().ToList() : context.Set<TEntitiy>().Where(filter).ToList();
            }
        }

        public List<TEntitiy> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void update(TEntitiy entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntitiy = context.Entry(entity);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
