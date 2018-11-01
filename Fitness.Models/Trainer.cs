using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Trainer
    {
        [Required]
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "Please provide Full name")]
        [Display(Name = "Full name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Please provide phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please provide e-mail address")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S+@\S+$")]
        public string Email { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short bio")]
        public string ShortBiography { get; set; }

        [Display(Name = "Photo")]
        public byte[] ImagePath { get; set; }

        public TrainingType TrainingType { get; set; }

        public int TrainingTypeId { get; set; }

    }
}
