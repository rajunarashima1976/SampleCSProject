using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCSWebProject.ModelsDTO
{
    public class DemandDTO
    {
        [Key]
        public int DemandId { get; set; }
        [Required]
        public string PrimarySkill { get; set; }
        [Required]
        public string SecondarySkill { get; set; }
        [Required]
        public DateTime StartByDate { get; set; }
        [Required]
        public float ExperienceInYears { get; set; }
        public string Location { get; set; }
    }
}
