using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        
    }
}