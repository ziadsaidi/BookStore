using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(BookStoreDbContext db) : base(db)
        {
        }
    }
}