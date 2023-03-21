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

        //to add a new part
        public void AddNewProduct(string PartName, decimal Price, int MaxPerCell)
        {
            Product prod = new Product()
            {
                ProductName = PartName,
                Price = Price,
                MaxPerCell = MaxPerCell
            };
            context.add(prod);
            context.SaveChanges();
        }

        //to change price of a part
        public void changePriceOfPart(int id, decimal newPrice)
        {
            var prod = context.Products.Where(p => p.ID == id).FirstOrDefault();

            if (prod is Product)
            {
                prod.Price = newPrice;
            }

            context.SaveChanges();
        }

        //to update a part
        public void UpdateProduct(string oldName, string newName)
        {
            var prod = context.Products.Where(p=>p.Name == oldName).FirstOrDefault();

            if (prod is Product)
            {
                prod.Name = newName;
            }

            context.SaveChanges();
        }

        public void UpdatePartDetails(string productName, decimal price, int maxPerCell)
        {
            var prod = context.Products.Where(p => p.Name == productName).FirstOrDefault();

            if (prod is Product)
            {
                prod.price = price;
                prod.maxPerCell = maxPerCell;
            }

            context.SaveChanges();
        }

        //to delete a part
        public void DeleteProduct(string name)
        {
            var prod = context.Products.Where(p => p.Name == name).FirstOrDefault();

            if (prod is Product)
            {
                context.Remove(prod);
            }

            context.SaveChanges();
        }

        //to count num of parts
        public Int64 CountProducts()
        {
            var count = context.Products.Where(x => x.InStock >= 1).Count();
            return count;
        }

        //the given partname is exists?
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