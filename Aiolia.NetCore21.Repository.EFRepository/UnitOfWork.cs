using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiolia.NetCore21.Repository.EFRepository
{
    public class UnitOfWork
    {
        public DbContext context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        //public T GetRepository<T>() where T :Repository
        //{
        //    if (dict.ContainsKey(typeof(T)))
        //    {
        //        return (T)dict[typeof(T)];
        //    }
        //    else
        //    {
        //        T t = new T(context);

        //    }
        //}

        //public Dictionary<Type, object> dict { get; set; }

        
    }
}
