using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCSWebProject.Models
{
    public class Demand
    {
        [Key]
        public int DemandId { get; set; }
        [Required]
        [DisplayName("Primary Skills")]
        public string PrimarySkills { get; set; }
        [Required]
        [DisplayName("Secondary Skills")]
        public string SecondarySkills { get; set; }
        [Required]
        [DisplayName("Location")]
        public string Location { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime? Start_By_Date { get; set; }
        [Required]
        [DisplayName("Experience")]
        public int Experience { get; set; }
    }
}
