using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class TrainingType
    {
        [Required]
        public int TrainingTypeId { get; set; }

        [Required(ErrorMessage = "Please insert training type name")]
        [Display(Name = "Training type")]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short training description")]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public byte[] ImagePath { get; set; }
    }
}
