﻿
using DataAccessLayer.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLogic.Interface
{
    public interface IProductReposity  //Interface are blueprint of a class or abstract method without implemention
    {
        Task<IEnumerable<Product>> GetAllProducts(); // this is an interface method that get all Products from the database
    }
}
