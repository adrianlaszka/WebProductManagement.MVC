using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class Product
    {
        public int Id { get; set; }
        public int MaxPerCell { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

    }
}
