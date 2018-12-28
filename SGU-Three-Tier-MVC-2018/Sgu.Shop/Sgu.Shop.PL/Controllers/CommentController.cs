using Sgu.StudentTesting.BLL.Contracts;
using Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Sgu.StudentTesting.DAL.Contracts;
using Sgu.StudentTesting.PL.ViewModel.Comment;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentLogic _commentLogic;
        private readonly IUserLogic _userLogic;

        public CommentController(ICommentLogic commentLogic, IUserLogic userLogic)
        {
            _commentLogic = commentLogic;
            _userLogic = userLogic;
        }
        #region General
        //GET: Commetn
        public ActionResult Index(int idShop)
        {
            var dlfkws = this._commentLogic.GetCommentsByShop(idShop);
            ViewData["IDShop"] = idShop;
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["IDUser"] = user.Name;
            var comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDisplayVM>>(dlfkws);
            return PartialView(comments);
        }
               
        public ActionResult Create(int idShop)
        {
            ViewData["IDShop"] = idShop;
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["IDUser"] = user.IDUser;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreateVM comment)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _commentLogic.AddComment(Mapper.Map<CommentCreateVM, Comment>(comment));
                    return RedirectToAction("Index", new { idShop = comment.IDShop });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex);
                }
            }
            return View(comment);
        }
        public ActionResult Edit(int id)
        {            
            return View(Mapper.Map<CommentCreateVM>(_commentLogic.GetCommentById(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentCreateVM comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentLogic.AddComment(Mapper.Map<CommentCreateVM, Comment>(comment));
                    return RedirectToAction("Index", new { idShop = comment.IDShop });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex);
                }
            }
            return View(comment);
        }
        public RedirectToRouteResult Back()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete (int id,int idShop)
        {
            ViewData["IDShop"] = idShop;
            ViewData["IDComment"] = id;
            return View(Mapper.Map<CommentDisplayVM>(_commentLogic.GetCommentById(id)));
        }
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(CommentDisplayVM comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _commentLogic.DeleteById(comment.IDComment);
                    return RedirectToAction("Index",new { idShop = comment.IDShop });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Delete", new { id=comment.IDComment , idShop=comment.IDShop});
        }

        #endregion
    }
}