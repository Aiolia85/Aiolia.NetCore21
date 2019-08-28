using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Aiolia.NetCore21.Domain;

namespace Aiolia.NetCore21.Repository.EFRepository
{
    public class Repository<T> : IRepository<T> where T :BaseEntity
    {

        public DbContext context { get; set; }
        
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public List<T> All()
        {
            return context.Set<T>().ToList();
        }

        public T Get(int Id)
        {
            return context.Set<T>().Where(o => o.Id == Id).FirstOrDefault();
        }

        public void Insert(T obj)
        {
            obj.CreateDate = DateTime.Now;
            context.Set<T>().Add(obj);
        }

        public void Remove(T obj)
        {
            context.Set<T>().Remove(obj);
        }

        public void Remove(int Id)
        {
            context.Set<T>().Remove(context.Set<T>().Find(Id));
        }

        public void Update(T obj)
        {
            var orig = context.Set<T>().Find(obj.Id);
            context.Entry(orig).CurrentValues.SetValues(obj);
        }

        public List<T> Pagination(IQueryable<T> Queryable, int page, int count)
        {
            return Queryable.Skip((page - 1) * count).Take(count).ToList();
        }
    }
}
