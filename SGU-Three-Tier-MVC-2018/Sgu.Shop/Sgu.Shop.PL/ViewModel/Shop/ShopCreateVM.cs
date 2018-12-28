using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace Sgu.StudentTesting.PL.ViewModel.Shop
{
    public class ShopCreateVM
    {
        public int IDShop { get; set; }
        public double Rating { get; set; }
        public byte[] Image { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameShop { get; set; }
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }
       
        [Required]
        public string City { get; set; }
        [MaxLength(50)]
        [Required]
        public string Website { get; set; }
        
        [Required]
        public string DescriptionShop { get; set; }
        [Phone]
        [Required]
        public string PhoneShop { get; set; }

        [Required]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):([0-5][0-9])", ErrorMessage = "Формат должен быть 09:30")]
        public string OpenHours { get; set; }

        [Required]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):([0-5][0-9])", ErrorMessage = "Формат должен быть 18:30")]
        public string CloseHours { get; set; }

        public int Moderator { get; set; }
    }
}