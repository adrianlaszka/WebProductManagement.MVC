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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SolutionLogic.Repository
{
    class ProjectDetailsRepository : IProjectDetailsRepository
    {
        private readonly string _db;
        public ProjectDetailsRepository(string db)
        {
            _db = db;
        }

        public void AddCustomerData(string customerData)
        {
                
        }

        public void AddProjectDescription(string description)
        {
            
        }

        public void AddProjectLocation(string location)
        {
            
        }

        public void AddWorkCost(string workcost)
        {
            
        }

        public void AddWorkDuration(string duration)
        {
            
        }

        public void UpdateCustomerData(string oldCustomerData, string newCustomerData)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @newCustomerData WHERE ... = @oldCustomerData";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newCustomerData", newCustomerData);
                command.Parameters.AddWithValue("@oldCustomerData", oldCustomerData);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateProjectDescription(string oldDescription, string newDescription)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @newDescription WHERE ... = @oldDescription";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newDescription", newDescription);
                command.Parameters.AddWithValue("@oldDescription", oldDescription);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
                
        }

        public void UpdateProjectLocation(string oldLocation, string newLocation)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @newLocation WHERE ... = @oldLocation";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newLocation", newLocation);
                command.Parameters.AddWithValue("@oldLocation", oldLocation);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateWorkCost(string oldWorkcost, string newWorkcost)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @newWorkcost WHERE ... = @oldWorkcost";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newWorkcost", newWorkcost);
                command.Parameters.AddWithValue("@oldWorkcost", oldWorkcost);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateWorkDuration(string oldDuration, string newDuration)
        {
            using (SqlConnection connection = new SqlConnection(_db))
            {
                string query = "UPDATE ... SET ... = @newDuration WHERE ... = @oldDuration";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newDuration", newDuration);
                command.Parameters.AddWithValue("@oldDuration", oldDuration);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
