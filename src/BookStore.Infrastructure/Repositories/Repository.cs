using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {


        protected readonly BookStoreDbContext Db;

        protected readonly DbSet<T> DbSet;

        protected Repository(BookStoreDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
        public virtual  async Task Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }



        public virtual async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(T entity)
        {
           DbSet.Remove(entity);
            await SaveChanges();
        }

        public async  Task<int> SaveChanges()
        {
             return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
             DbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}