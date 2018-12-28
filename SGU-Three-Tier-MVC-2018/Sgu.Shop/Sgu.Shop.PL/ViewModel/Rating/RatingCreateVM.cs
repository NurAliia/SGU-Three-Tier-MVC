using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Rating
{
    public class RatingCreateVM
    {        
        [Required]
        public int IDShop { get; set; }
        [Required]
        public int IDUser { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}