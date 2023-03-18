﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class ProjectDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public String projectLocation { get; set; }
        public String projectDescription { get; set; }
        public String customerData { get; set; }
        public int workDuration { get; set; }
        public int workCost { get; set; }

    }
}