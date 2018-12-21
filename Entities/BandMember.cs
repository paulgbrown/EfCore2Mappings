using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class BandMember
    {
        public int BandMemberId { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }

        public int PersonId { get; set; }

        public Person Member { get; set; }

        public int InstrumentId { get; set; }

        public Instrument Instrument { get; set; }

        [Required]
        [MaxLength(15)]
        public string Term { get; set; }
    }
}
