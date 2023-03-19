
using DataAccessLayer.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLogic.Interface
{
    public interface IProjectDetailsRepository
    {
        public Task<IEnumerable<Product>> GetAllProjects();

        public void AddNewProject(string projectLocation, string projectDescription, string customerData,
            int workDuration, int workCost);

        public void DeleteProject(int id);

        public Int64 CountProjects();

        public void UpdateProjectLocation(int projectId, string newLocation);

        public void UpdateProjectDescription(int projectId, string newDescription);

        public void UpdateCustomerData(int projectId, string newCustomerData);

        public void UpdateWorkDuration(int projectId, int newWorkDuration);

        public void UpdateWorkCost(int projectId, int newWorkCost);
    }
}
