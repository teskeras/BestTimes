using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestTimes.Models
{
    public class BestTimeFormModel
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [Required]
        [Range(0, 23, ErrorMessage = "Can only be between 0 .. 23")]
        public int Hours { get; set; }
        [Required]
        [Range(0, 59, ErrorMessage = "Can only be between 0 .. 59")]
        public int Minutes { get; set; }
        [Required]
        [Range(0, 59, ErrorMessage = "Can only be between 0 .. 59")]
        public int Seconds { get; set; }
        [Required]
        [Range(0, 999, ErrorMessage = "Can only be between 0 .. 999")]
        public int Miliseconds { get; set; }

    }
}
