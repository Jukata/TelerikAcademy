using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T item);
        void Update(int id, T item);
        void Remove(int id);
    }
}