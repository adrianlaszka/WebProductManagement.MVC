using DataAccessLayer;
using DataAccessLayer.DataTable;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using SolutionLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;

namespace SolutionLogic.Repository
{
    public class ProductRepository : IProductReposity  // This is where I give implementation to the interface method created 
    {
        SolarPanelContext context = new SolarPanelContext();
        private readonly string _db;
        public ProductRepository(string db)
        {
            _db = db;
        }

        // this is the complete implemetation of the interface that returns all products from the database with instack greater than one
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            // Select * from Products where Instock > 1
            return await context.Products.Where(x => x.InStock >= 1).ToListAsync();
        }

        //to add a new product
        public void AddNewProduct(string newProduct, int MaxPerCell, decimal Price, int InStock)
        {
            Product prod = new Product()
            {
                ProductName = newProduct,
                Price = Price,
                InStock = InStock,
                MaxPerCell = MaxPerCell
            };
            context.add(prod);
            context.SaveChanges();
        }

        //to update a product
        public void UpdateProduct(string oldName, string newName)
        {
            var prod = context.Products.Where(p=>p.Name == oldName).FirstOrDefault();

            if (prod is Product)
            {
                prod.Name = newName;
            }

            context.SaveChanges();
        }

        //to delete a product
        public void DeleteProduct(string name)
        {
            var prod = context.Products.Where(p => p.Name == name).FirstOrDefault();

            if (prod is Product)
            {
                context.Remove(prod);
            }

            context.SaveChanges();
        }

        //to count products
        public Int64 CountProducts()
        {
            var count = context.Products.Where(x => x.InStock >= 1).Count();
            return count;
        }

        //the given productname is exists?
        public bool Exists(string productName)
        {
            var prod = context.Products.Where(p => p.Name == productName).FirstOrDefault();

            if (prod is Product)
            {
                return true;
            }

            return false;
        }
    }
}