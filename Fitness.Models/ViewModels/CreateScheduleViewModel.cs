using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateScheduleViewModel
    {
        public List<Trainer> Trainers { get; set; }

        [Display(Name = "Training types")]
        public List<TrainingType> TrainingTypes { get; set; }

        public List<Schedule> Schedules { get; set; }

        public Schedule Schedule { get; set; }
    }
}
