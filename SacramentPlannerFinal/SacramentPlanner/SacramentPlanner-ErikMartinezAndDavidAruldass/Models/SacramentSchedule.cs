using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Models
{
    public class SacramentSchedule
    {
        //The ID field is required by the database for the primary key.
        [Key]
        public int SacramentScheduleId { get; set; }
      
        //Date
        [DataType(DataType.Date)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }

        //Presiding
        [Display(Name = "Presiding")]
        public int BishopricId { get; set; }


        //Hymns
        [Display(Name = "Opening Hymn")]
        public int OpeningHymnId { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public int SacramentalHymnId { get; set; }
        [Display(Name = "Intermediate Hymn (Optiional)")]
        public int? IntermediateHymnId { get; set; }
        [Display(Name = "Closing Hymn")]
        public int ClosingHymnId { get; set; }


        //Speakers
        [Display(Name = "Opening Speaker")]
        public int OpeningSpeakerId { get; set; }
        [Display(Name = "Speaker (Optiional)")]
        public int? IntermediateSpeakerId { get; set; }
        [Display(Name = "Closing Speaker")]
        public int ClosingSpeakerId { get; set; }

        //Prayers
        [Display(Name = "Invocation")]
        public int InvocationId { get; set; }
        [Display(Name = "Benediction")]
        public int BenedictionId { get; set; }

        /* navigation properties */
        //Reference for BISHOPRiC
        public Bishopric Bishopric { get; set; }

        //HYMNS
        public Hymn OpeningHymn { get; set; }

        public Hymn SacramentalHymn { get; set; }

        public Hymn IntermediateHymn { get; set; }

        public Hymn ClosingHymn { get; set; }

        //SPEAKERS
        public Speaker OpeningSpeaker { get; set; }

        public Speaker IntermediateSpeaker { get; set; }

        public Speaker ClosingSpeaker { get; set; }

        //PRAYERS (MEMBERS)
        public Member Invocation { get; set; }
        public Member Benediction { get; set; }
        
        

        //public Hymn Hymn { get; set; }
        //public Speaker Speaker { get; set; }        
    }
}
