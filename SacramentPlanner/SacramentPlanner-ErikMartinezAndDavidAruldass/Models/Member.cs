using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

        [InverseProperty("Invocation")]
        ICollection<SacramentSchedule> Invocation { get; set; }

        [InverseProperty("Benediction")]
        ICollection<SacramentSchedule> Benediction { get; set; }

        //public ICollection<SacramentSchedule> SacramentSchedule { get; set; }
    }
}
