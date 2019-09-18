using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentPlanner.Models;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public int MemberId { get; set; }
        public string Topic { get; set; }

        public Member Member { get; set; }

        /* navigation properties */
        [InverseProperty("OpeningSpeaker")]
        ICollection<SacramentSchedule> OpeningSpeaker { get; set; }

        [InverseProperty("IntermediateSpeaker")]
        ICollection<SacramentSchedule> IntermediateSpeaker { get; set; }

        [InverseProperty("ClosingSpeaker")]
        ICollection<SacramentSchedule> ClosingSpeaker { get; set; }

       //public ICollection<SacramentSchedule> SacramentSchedule { get; set; }
    }
}
