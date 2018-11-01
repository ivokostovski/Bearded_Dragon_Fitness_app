using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ListTrainingTypesViewModel
    {
        [Display(Name = "Trainers")]
        public List<Trainer> Trainers { get; set; }

        [Display(Name = "Training types")]
        public List<TrainingType> TrainingTypes { get; set; }

        public TrainingType TrainingType { get; set; }

        public Trainer Trainer { get; set; }
    }
}
