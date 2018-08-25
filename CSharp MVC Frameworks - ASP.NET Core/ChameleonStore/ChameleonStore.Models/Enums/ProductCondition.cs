using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChameleonStore.Models.Enums
{
    public enum ProductCondition
    {
        [Display(Name = "Brand new")]
        BrandNew = 0,
        [Display(Name = "Very good")]
        VeryGood = 1,
        [Display(Name = "Good")]
        Good = 2,
        [Display(Name = "Acceptable")]
        Acceptable = 3
    }
}
