
using DataAccessLayer.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLogic.Interface
{
    public interface IProductReposity  //Interface are blueprint of a class or abstract method without implemention
    {
        public List<string> GetAllProducts(); // this is an interface method that get all Products from the database

        public void AddNewProducts(string name);

        public void UpdateProduct(string oldName, string newName);

        public void DeleteProduct(string name);

        public Int64 CountProducts();

        public bool Exists(string productName);
    }
}
