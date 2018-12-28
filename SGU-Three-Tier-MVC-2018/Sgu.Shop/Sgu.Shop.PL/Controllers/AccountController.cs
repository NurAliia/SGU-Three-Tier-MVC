using System.Web.Mvc;
using Sgu.StudentTesting.PL.Models;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using System.Web.Security;
using AutoMapper;
using System.Security.Principal;
using Sgu.StudentTesting.PL.ViewModels.User;
using System.Collections.Generic;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserLogic _userLogic;

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool exist = _userLogic.CheckLoginUser(model.Email, model.Password);
                // поиск пользователя в бд                           
                if (exist)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // создаем нового пользователя
                    _userLogic.AddUser(new Common.User
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        Patronymic = model.Patronymic,
                        EMail = model.Email,
                        Password = model.Password,
                        Phone = model.Phone
                    });
                    User user = _userLogic.GetUserByEMail(model.Email);
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public PartialViewResult GetUserInfo()
        {

            var user = _userLogic.GetUserByEMail(User.Identity.Name) ?? new Common.User();

            var userDisplay = new UserDisplayVM()
            {
                IDUser = user.IDUser,
                Name = user.Name
            };
            return PartialView("LoginPartial", userDisplay);
        }

        public RedirectToRouteResult Details(int id)
        {
            return RedirectToAction("Details", "User", new { id = id });
        }
    }
}