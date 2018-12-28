using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Comment
{
    public class CommentDisplayVM
    {
        public int IDComment { get; set; }
        public int IDShop { get; set; }
        public string NameUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}