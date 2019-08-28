using Aiolia.NetCore21.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiolia.NetCore21.Repository
{
    public interface IRepository<T> where T: BaseEntity
    {
        void Remove(T obj);
        void Remove(int Id);

        List<T> All();
        T Get(int Id);

        void Update(T obj);
        void Insert(T obj);
    }
}
