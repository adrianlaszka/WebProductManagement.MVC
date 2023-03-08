using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class Location
    {
        public int LocationID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProducts { get; set; }
        public int MaxNumberOfProductPerCell { get; set; }

    }
}