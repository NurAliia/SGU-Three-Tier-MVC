using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Comment
{
    public class CommentCreateVM
    {
        public int IDUser { get; set; }
        [MaxLength(450)]
        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int IDShop { get; set; }
    }
}