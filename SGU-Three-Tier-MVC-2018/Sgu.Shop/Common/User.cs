using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Common
{
    public class User
    {
        public int IDUser { get; set; }

        public string Name { get; set; }
        
        public string LastName { get; set; }
       
        public string Patronymic { get; set; }
                      
        public string EMail { get; set; }        
      
        public string Password { get; set; }

        public string Phone { get; set; }

        public User() { }
    }
}