using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()

    {
        DataContext dataContext = new DataContext();
        DbSet<T> data;
        public GenericRepository()
        {
            data = dataContext.Set<T>();
        }
        public void Delete(T p)
        {
            data.Remove(p);
            dataContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return data.Find(id);
        }

        public void Insert(T p)
        {
            data.Add(p);
            dataContext.SaveChanges();
        }

        public List<T> List()
        {
            return data.ToList();
        }

        public void Update(T p)
        {
            dataContext.Entry<T>(p).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}
