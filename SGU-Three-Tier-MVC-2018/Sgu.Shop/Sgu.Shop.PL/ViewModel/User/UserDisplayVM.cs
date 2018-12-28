//using Sgu.StudentTesting.PL.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModels.User
{
    public class UserDisplayVM    
    {
        public int IDUser { get; set; }
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

    }
}