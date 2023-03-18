
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
        public void AddProjectLocation(string location);
        public void UpdateProjectLocation(string oldLocation, string newLocation);

        public void AddProjectDescription(string description);
        public void UpdateProjectDescription(string oldDescription, string newDescription);

        public void AddCustomerData(string customerData);
        public void UpdateCustomerData(string oldCustomerData, string newCustomerData);

        public void AddWorkDuration(string duration);
        public void UpdateWorkDuration(string oldDuration, string newDuration);

        public void AddWorkCost(string workcost);
        public void UpdateWorkCost(string oldWorkcost, string newWorkcost);
    }
}
