using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTable
{
    public class ProjectStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int projectID { get; set; }
        public string projectCurrentStat { get; set; }
        public DateTime statusChanged { get; set; }

        [ForeignKey("projectID")]
        public virtual ProjectDetails ProjectDetails { get; set; }


    }
}
