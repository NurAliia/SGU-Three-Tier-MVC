namespace Sgu.StudentTesting.PL.Controllers
{
    using Sgu.StudentTesting.BLL.Contracts;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;

        public HomeController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Index()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            int x = _userLogic.GetRoleUser(user.IDUser);
            ViewData["role"] = x;
            ViewData["IdUser"] = user.IDUser;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public RedirectToRouteResult Subject(int id, int role)
        {
            if (role == 2)
            {
                return RedirectToAction("Index", "Subject", new { id = id });
            }
            else
            {
                return RedirectToAction("IndexForTeacher", "Subject", new { id = id });
            }
        }
        public RedirectToRouteResult Tests(int id)
        {
            return RedirectToAction("Index", "Test", new { id = id });
        }
        public RedirectToRouteResult NewModerator()
        {
            return RedirectToAction("ListRequestRights", "User");
        }
        public RedirectToRouteResult IndexForModerator()
        {
            return RedirectToAction("IndexForModerator", "Shop");
        }
        public RedirectToRouteResult CreateShop()
        {
            return RedirectToAction("Create", "Shop");
        }
        public RedirectToRouteResult IndexShop()
        {
            return RedirectToAction("ListShops", "Shop");
        }        
        public RedirectToRouteResult IndexUser()
        {
            return RedirectToAction("Index", "User");
        }
    }
}