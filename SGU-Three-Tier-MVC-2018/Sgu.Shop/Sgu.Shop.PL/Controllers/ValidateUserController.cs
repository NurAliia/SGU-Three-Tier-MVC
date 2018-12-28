using Sgu.StudentTesting.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Sgu.StudentTesting.PL.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidateUserController : Controller
    {
        private readonly IUserLogic _userLogic;

        public ValidateUserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        // GET: ValidateUserEmail
        public JsonResult ValidateLogin(string EMail)
        {
            if (_userLogic.GetUserByEMail(EMail) == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}