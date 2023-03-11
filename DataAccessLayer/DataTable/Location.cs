﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProducts { get; set; }
        public int MaxNumberOfProductPerCell { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

    }
}