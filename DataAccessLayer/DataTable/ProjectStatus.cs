using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class ProjectStatus
    {
        public int Id { get; set; }
        public int projectID { get; set; }
        public int projectCurrentStat { get; set; }
        public DateTime statusChanged { get; set; }

    }
}
