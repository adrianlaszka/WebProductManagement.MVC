using System;
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
        [Required]
        public String projectDescription { get; set; }
        [Required]
        public String customerData { get; set; }
        [Required]
        public int workDuration { get; set; }
        [Required]
        public int workCost { get; set; }

    }
}
