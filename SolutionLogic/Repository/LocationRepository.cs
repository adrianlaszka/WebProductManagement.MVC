using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SolutionLogic.Repository
{
    internal class LocationRepository
    {
        SolarPanelContext context = new SolarPanelContext();

        private readonly string _db;
        public LocationRepository(string db)
        {
            _db = db;
        }
    }
}
