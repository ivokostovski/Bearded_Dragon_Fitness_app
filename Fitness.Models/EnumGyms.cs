using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum EnumGyms
    {
        [Display(Name = "Palmyra")]
        Palmyra,
        [Display(Name = "Babylon")]
        Babylon,
        [Display(Name = "Petra")]
        Petra
    }
}
