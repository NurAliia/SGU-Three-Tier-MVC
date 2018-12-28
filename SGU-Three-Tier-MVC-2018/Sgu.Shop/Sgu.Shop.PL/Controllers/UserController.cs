using Sgu.StudentTesting.BLL.Contracts;
using Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Sgu.StudentTesting.DAL.Contracts;
using Sgu.StudentTesting.PL.ViewModels.User;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        #region General

        // GET: User        
        public ActionResult Index()
        {
            var user = _userLogic.GetUsers();
            
           var a = Mapper.Map<IEnumerable<User>, IEnumerable<UserDisplayVM>>(user);
            return this.View(a);
        }
        public RedirectToRouteResult IndexShop()
        {
            return RedirectToAction("Index","Shop");
        }
        public RedirectToRouteResult IndexHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetModerators()
        {
            var user = _userLogic.GetModerators();
            var a = Mapper.Map<IEnumerable<User>, IEnumerable<UserDisplayVM>>(user);
            return this.View(a);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userLogic.AddUser(Mapper.Map<UserCreateVM, User>(user));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            return this.View(Mapper.Map<UserCreateVM>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Edit(UserCreateVM user)
        {            
            try
            {
                var userCurrent = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

                if (ModelState.IsValid)
                {
                    var userUp = Mapper.Map<User>(user);
                    userUp.IDUser = userCurrent.IDUser;
                    this._userLogic.Update(userUp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Details");
        }

        public ActionResult Delete(int id)
        {
            return this.View("DeleteConfirmation", Mapper.Map<UserDisplayVM>(this._userLogic.GetUserById(id)));
        }
        //Confirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserDisplayVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._userLogic.Delete(user.IDUser);
                    return this.RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Delete");
        }
        public ActionResult Details()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            int x = _userLogic.GetRoleUser(user.IDUser);
            ViewData["role"] = x;

            return this.View(Mapper.Map<User, UserDisplayVM>(this._userLogic.GetUserById(user.IDUser)));
        }
        [HttpPost]
        public ActionResult DetailsPost(int id)
        {
            _userLogic.RequestRights(id);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ListRequestRights()
        {
            return View(Mapper.Map<IEnumerable<User>, IEnumerable<UserDisplayVM>>(_userLogic.ListRequestRights()));
        }
        public ActionResult AcceptedModerator(int id)
        {
            _userLogic.DeleteRequestRights(id);
            return RedirectToAction("ListRequestRights");
        }
        public ActionResult NotAcceptedModerator(int id)
        {
            _userLogic.DeleteRequestRights(id);
            return RedirectToAction("ListRequestRights");
        }
        #endregion general
    }
}