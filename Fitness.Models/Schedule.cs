using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Models
{
    
    public class Schedule
    {
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "Please choose a day")]
        public EnumDays Days { get; set; }

        [Required(ErrorMessage = "Please enter starting time")]
        [Display(Name = "From")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please enter ending time")]
        [Display(Name = "To")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public EnumGyms Gyms { get; set; }

        public Trainer Trainer { get; set; }

        public int TrainerId { get; set; }
    }
}
