﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public enum EnumDays
    {
        [Display(Name = "Monday")]
        Monday,
        [Display(Name = "Tuesday")]
        Tuesday,
        [Display(Name = "Wednesday")]
        Wednesday,
        [Display(Name = "Thursday")]
        Thursday,
        [Display(Name = "Friday")]
        Friday,
        [Display(Name = "Saturday")]
        Saturday,
        [Display(Name = "Sunday")]
        Sunday

    }
}
