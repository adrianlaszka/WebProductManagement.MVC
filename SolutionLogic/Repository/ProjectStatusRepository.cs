using DataAccessLayer.DataTable;
using SolutionLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLogic.Repository
{
    public class ProjectStatusRepository
    {
        SolarPanelContext context = new SolarPanelContext();

        //to get project current state by ID
        public int GetProjectCurrentStateByID(int id)
        {
            return context.ProjectStatus.Where(x => x.ID = id).ProjectCurrentState;
        }

        //to update project current state
        public void UpdateProjectCurrentState(int id, int state)
        {
            var projectStatus = context.ProjectStatus.Where(p => p.ID == id).FirstOrDefault();

            if (projectStatus is ProjectStatus)
            {
                projectStatus.projectCurrentStat = state;
            }
            context.SaveChanges();
        }
       
    }
}
