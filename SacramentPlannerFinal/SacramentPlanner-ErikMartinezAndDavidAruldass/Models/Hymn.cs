using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Models
{
    public class Hymn
    {        
        public int HymnId { get; set; }
        [Display(Name = "Hymn Name")] // puts spaces inbeween words
        public string HymnName { get; set; }
        [Display(Name = "Hymn Number")]  // puts spaces inbeween words
        public int HymnNumber { get; set; }

        /* navigation properties */
        [InverseProperty("OpeningHymn")]
        ICollection<SacramentSchedule> OpeningHymns { get; set; }

        [InverseProperty("SacramentalHymn")]
        ICollection<SacramentSchedule> SacramentalHymns { get; set; }

        [InverseProperty("IntermediateHymn")]
        ICollection<SacramentSchedule> IntermediateHymns { get; set; }

        [InverseProperty("ClosingHymn")]
        ICollection<SacramentSchedule> ClosingHymns { get; set; }

        //public ICollection<SacramentSchedule> SacramentSchedule { get; set; }
    }
}
