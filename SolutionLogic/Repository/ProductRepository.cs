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

namespace SolutionLogic.Repository
{
    public class ProductRepository : IProductReposity  // This is where I give implementation to the interface method created 
    {
        private readonly string _db;
        public ProductRepository(string db)
        {
            _db = db;
        }

        /*public async Task<IEnumerable<Product>> GetAllProducts() // this is the complete implemetation of the interface taht return all products from the database with instack greater than one
        {
            // Select * from Products where Instock > 1
            return await _db.Products.Where(x => x.InStock >= 1).ToListAsync();
        }*/

        //to get all products
        public List<string> GetAllProducts()
        {
            List<string> products = new List<string>();
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "SELECT ... FROM ...";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    products.Add(name);
                }
                connection.Close();
            }
            return products;
        }

        //to add new products
        public void AddNewProducts(string name)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "INSERT INTO ... (...) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //to modify a product
        public void UpdateProduct(string oldName, string newName)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @NewName WHERE ... = @OldName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewName", newName);
                command.Parameters.AddWithValue("@OldName", oldName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //to delete a product
        public void DeleteProduct(string name)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "DELETE FROM ... WHERE ... = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //to count products
        public Int64 CountProducts()
        {
            string query;
            using (SqlConnection connection = new SqlConnection(_db))
            {
                query = "SELECT Count(*) FROM ... ";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Convert.ToInt64(query);
        }

        //the given productname is exists?
        public bool Exists(string productName)
        {
            Int64 numberOfProducts = CountProducts();
            return numberOfProducts > 0;
        }
    }
}