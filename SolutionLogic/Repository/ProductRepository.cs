using DataAccessLayer;
using DataAccessLayer.DataTable;
using Microsoft.EntityFrameworkCore;

using SolutionLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLogic.Repository
{
     public class ProductRepository : IProductReposity  // This is where I give implementation to the interface method created 
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db =db;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() // this is the complete implemetation of the interface taht return all products from the database with instack greater than one
        {
            // Select * from Products where Instock > 1
            return await _db.Products.Where(x => x.InStock >= 1).ToListAsync();
        }
    }
}
