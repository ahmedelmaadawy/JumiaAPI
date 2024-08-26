using JumiaEcommeceAPI.DataAccess.Context;
using JumiaEcommeceAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace JumiaEcommeceAPI.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext Context;
        private DbSet<T> DbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public void add(T item)
        {
            DbSet.Add(item);
        }

        public void delete(T item)
        {
            DbSet.Remove(item);
        }

        public IEnumerable<T> getAll()
        {
            return DbSet.ToList();
        }

        public T getById(int id)
        {
            return DbSet.Find(id);
        }

        public void save()
        {
            Context.SaveChanges();
        }

        public void update(T item)
        {
            DbSet.Update(item);
        }
    }
}
