using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Comment
    {
        public int IDComment { get; set; }
        public int IDUser { get; set; } 
        public string NameUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int IDShop { get; set; }
    }
}
