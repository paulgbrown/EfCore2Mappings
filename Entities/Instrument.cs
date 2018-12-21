using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Instrument
    {
        public int InstrumentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
