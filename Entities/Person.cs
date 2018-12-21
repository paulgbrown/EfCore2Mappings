using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
