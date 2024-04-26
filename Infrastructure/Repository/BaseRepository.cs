using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceDbContext _context;
        public BaseRepository(EcommerceDbContext c)
        {
                _context = c;
        }

        public int Delete(int id)
        {
            var i = GetById(id);
            if (i != null)
            {
                _context.Set<T>().Remove(i);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
