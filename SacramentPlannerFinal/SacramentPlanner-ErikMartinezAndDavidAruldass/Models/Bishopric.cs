using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Models
{
    public class Bishopric
    {
        public int BishopricId { get; set; }

        //below code puts spaces inbetween the name
        [Display(Name = "Bishopric Name")]
        public string BishopricName { get; set; }
        public bool Released { get; set; }

        public ICollection<SacramentSchedule> SacramentSchedule { get; set; }
    }
}
