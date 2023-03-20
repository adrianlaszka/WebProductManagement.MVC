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
using System.Data;

namespace SolutionLogic.Repository
{
    class ProjectDetailsRepository : IProjectDetailsRepository
    {

        SolarPanelContext context = new SolarPanelContext();

        private readonly string _db;
        public ProjectDetailsRepository(string db)
        {
            _db = db;
        }

        //to get all projects
        public async Task<IEnumerable<Product>> GetAllProjects()
        {
            return await context.ProjectDetails.Where(x => x.ID > 0).ToListAsync();
        }

        //to add a new project
        public void AddNewProject(string projectLocation, string projectDescription, string customerData,
            int workDuration, int workCost)
        {
            ProjectDetails proj = new ProjectDetails()
            {
                projectLocation = projectLocation,
                projectDescription = projectDescription,
                customerData = customerData,
                workDuration = workDuration,
                workCost = workCost
            };
            context.add(proj);
            context.SaveChanges();
        }

        //to delete a project by ID
        public void DeleteProject(int id)
        {
            var proj = context.ProjetDetails.Where(p => p.ID == id).FirstOrDefault();

            if (proj is ProjectDetails)
            {
                context.Remove(proj);
            }

            context.SaveChanges();
        }

        //to count projects
        public Int64 CountProjects()
        {
            var count = context.ProjectDetails.Where(x => x.ID >= 1).Count();
            return count;
        }

        //to update project location
        public void UpdateProjectLocation(int projectId, string newLocation)
        {
            var prod = context.Products.Where(p => p.ID == projectId).FirstOrDefault();

            if (prod is ProjectDetails)
            {
                prod.projectLocation = newLocation;
            }

            context.SaveChanges();
        }

        //to update project description
        public void UpdateProjectDescription(int projectId, string newDescription)
        {
            var prod = context.Products.Where(p => p.ID == projectId).FirstOrDefault();

            if (prod is ProjectDetails)
            {
                prod.projectDescription = newDescription;
            }

            context.SaveChanges();
        }

        //to update customer data
        public void UpdateCustomerData(int projectId, string newCustomerData)
        {
            var prod = context.Products.Where(p => p.ID == projectId).FirstOrDefault();

            if (prod is ProjectDetails)
            {
                prod.customerData = newCustomerData;
            }

            context.SaveChanges();
        }

        //to update work duration
        public void UpdateWorkDuration(int projectId, int newWorkDuration)
        {
            var prod = context.Products.Where(p => p.ID == projectId).FirstOrDefault();

            if (prod is ProjectDetails)
            {
                prod.workDuration = newWorkDuration;
            }

            context.SaveChanges();
        }

        //to update work cost
        public void UpdateWorkCost(int projectId, int newWorkCost)
        {
            var prod = context.Products.Where(p => p.ID == projectId).FirstOrDefault();

            if (prod is ProjectDetails)
            {
                prod.workCost = newWorkCost;
            }

            context.SaveChanges();
        }
    }
}
