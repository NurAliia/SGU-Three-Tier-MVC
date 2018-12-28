using AutoMapper;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.PL.ViewModel.Shop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopLogic _shopLogic;
        private readonly IRatingLogic _ratingLogic;
        private readonly IUserLogic _userLogic;

        public ShopController(IShopLogic shopLogic, IUserLogic userLogic, IRatingLogic ratingLogic)
        {
            _shopLogic = shopLogic;
            _userLogic = userLogic;
            _ratingLogic = ratingLogic;
        }
        #region General
        //GET: Shop
        public ActionResult Index(IEnumerable<ShopDisplayVM> shops, int idSort)
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["UserRole"] = _userLogic.GetRoleUser(user.IDUser);
            ViewData["IDUser"] = user.IDUser;
            ViewData["Sort"] = idSort;

            List<SelectListItem> nameShops = new List<SelectListItem>();
            List<SelectListItem> descriptionShops = new List<SelectListItem>();
            foreach (Shop i in _shopLogic.GetShops())
            {
                nameShops.Add(new SelectListItem { Text = i.NameShop.ToString(), Value = i.NameShop.ToString() });
                descriptionShops.Add(new SelectListItem { Text = i.DescriptionShop.ToString(), Value = i.DescriptionShop.ToString() });

            }
            ViewData["NameShop"] = nameShops;
            ViewData["Description"] = descriptionShops;
            return View(shops);
        }
        [HttpGet]
        public ActionResult ListShops()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["UserRole"] = _userLogic.GetRoleUser(user.IDUser);
            ViewData["IDUser"] = user.IDUser;
            ViewData["Sort"] = 0;

            List<SelectListItem> nameShops = new List<SelectListItem>();
            List<SelectListItem> descriptionShops = new List<SelectListItem>();
            foreach (Shop i in _shopLogic.GetShops())
            {
                nameShops.Add(new SelectListItem { Text = i.NameShop.ToString(), Value = i.NameShop.ToString() });
                descriptionShops.Add(new SelectListItem { Text = i.DescriptionShop.ToString(), Value = i.DescriptionShop.ToString() });

            }
            ViewData["NameShop"] = nameShops;
            ViewData["Description"] = descriptionShops;
            IEnumerable<ShopDisplayVM> shopsList = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(this._shopLogic.GetShops());
            foreach (var shop in shopsList)
            {
                shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
            }
            return View(shopsList);
        }
        public ActionResult SortShops()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["UserRole"] = _userLogic.GetRoleUser(user.IDUser);
            ViewData["IDUser"] = user.IDUser;
            ViewData["Sort"] = 1;

            List<SelectListItem> nameShops = new List<SelectListItem>();
            List<SelectListItem> descriptionShops = new List<SelectListItem>();
            foreach (Shop i in _shopLogic.GetShops())
            {
                nameShops.Add(new SelectListItem { Text = i.NameShop.ToString(), Value = i.NameShop.ToString() });
                descriptionShops.Add(new SelectListItem { Text = i.DescriptionShop.ToString(), Value = i.DescriptionShop.ToString() });

            }
            ViewData["NameShop"] = nameShops;
            ViewData["Description"] = descriptionShops;
            var shops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(this._shopLogic.GetShops());
            foreach (var shop in shops)
            {
                shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
            }
            return View(shops.OrderByDescending(n => n.Rating));
        }
        public ActionResult SelectShops(string NameShop, string Description)
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            ViewData["UserRole"] = _userLogic.GetRoleUser(user.IDUser);
            ViewData["IDUser"] = user.IDUser;
            ViewData["Sort"] = 0;

            List<SelectListItem> nameShops = new List<SelectListItem>();
            List<SelectListItem> descriptionShops = new List<SelectListItem>();
            foreach (Shop i in _shopLogic.GetShops())
            {
                nameShops.Add(new SelectListItem { Text = i.NameShop.ToString(), Value = i.NameShop.ToString() });
                descriptionShops.Add(new SelectListItem { Text = i.DescriptionShop.ToString(), Value = i.DescriptionShop.ToString() });

            }
            ViewData["NameShop"] = nameShops;
            ViewData["Description"] = descriptionShops;
            var shops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(this._shopLogic.GetShops());
            foreach (var shop in shops)
            {
                shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
            }

            IEnumerable<ShopDisplayVM> selectedShops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(_shopLogic.GetShops());
            if (NameShop != "Не выбрано" && Description != "Не выбрано")
            {
                var a = _shopLogic.GetShopsByName(NameShop);
                var b = _shopLogic.GetShopsByDescription(Description);
                selectedShops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(a.Union(b));
            }
            else
            {
                if (NameShop == "Не выбрано")
                {
                    if (Description != "Не выбрано")
                        selectedShops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(_shopLogic.GetShopsByDescription(Description));
                }
                else
                {
                    if (Description == "Не выбрано")
                    {
                        selectedShops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(_shopLogic.GetShopsByName(NameShop));
                    }
                }
            }
            foreach (var shop in selectedShops)
            {
                shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
            }
            return View(selectedShops);

        }
        public ActionResult IndexForModerator()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();
            IEnumerable<Shop> listShop = this._shopLogic.GetShopsByModerator(user.IDUser);
            var shops = Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(listShop);
            if (shops.Count() == 0)
            {
                return Index(Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDisplayVM>>(this._shopLogic.GetShops()), 0);
            }
            foreach (var shop in shops)
            {
                shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
            }
            return View(shops);
        }
        public ActionResult Create()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            foreach (City i in _userLogic.GetCity())
            {
                cities.Add(new SelectListItem { Text = i.NameCity.ToString(), Value = i.IDCity.ToString() });
            }
            ViewData["City"] = cities;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCreateVM shop, HttpPostedFileBase uploadFile)
        {
            try
            {
                if (uploadFile != null)
                {
                    if (uploadFile.ContentLength > 0)
                    {
                        if (Path.GetExtension(uploadFile.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(uploadFile.FileName).ToLower() == ".png"
                            || Path.GetExtension(uploadFile.FileName).ToLower() == ".gif"
                            || Path.GetExtension(uploadFile.FileName).ToLower() == ".jpeg")
                        {
                            HttpPostedFileBase uploadFileCopy = uploadFile;
                            string ImageName = System.IO.Path.GetFileName(uploadFileCopy.FileName); //file2 to store path and url  
                            string physicalPath = Server.MapPath("~/img/" + ImageName);
                            // save image in folder  
                            uploadFileCopy.SaveAs(physicalPath);
                            byte[] mas = new byte[uploadFile.ContentLength];
                            uploadFile.InputStream.Read(mas, 0, uploadFile.ContentLength);
                            shop.Image = mas;
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    shop.Moderator = (_userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User()).IDUser;

                    _shopLogic.AddShop(Mapper.Map<ShopCreateVM, Shop>(shop));
                    return RedirectToAction("IndexForModerator");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(shop);
        }
        public ActionResult Edit(int id)
        {
            ViewData["IDShop"] = id;
            var shop = _shopLogic.GetShopById(id);
            return View(Mapper.Map<ShopCreateVM>(shop));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopCreateVM shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    shop.Rating = _ratingLogic.GetRatingShopById(shop.IDShop);
                    _shopLogic.Update(Mapper.Map<ShopCreateVM, Shop>(shop));
                    return RedirectToAction("IndexForModerator");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(shop);
        }
        public RedirectToRouteResult Back()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int id)
        {
            var shop = Mapper.Map<Shop, ShopDisplayVM>(_shopLogic.GetShopById(id));
            shop.Rating = _ratingLogic.GetRatingShopById(id);
            ViewData["IDShop"] = id;
            return View(shop);
        }
        [HttpPost]
        public RedirectToRouteResult DetailsPost(int idShop, int reviewStars)
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();
            _ratingLogic.AddRating(new Rating { IDShop = idShop, IDUser = user.IDUser, Grade = reviewStars });
            return RedirectToAction("ListShops");
        }
        public ActionResult Delete(int id)
        {
            var a = Mapper.Map<Shop, ShopDisplayVM>(_shopLogic.GetShopById(id));
            ViewData["IDShop"] = id;
            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult DeletePost(int idShop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _shopLogic.DeleteById(idShop);
                    return RedirectToAction("IndexForModerator");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Delete");
        }
        [HttpGet]
        public RedirectToRouteResult Comments(int id)
        {
            return RedirectToAction("Index", "Comment", new { idShop = id });
        }
        [HttpPost]
        public ActionResult GetImage(byte[] image)
        {
            return File(image,"image/jpeg");
        }

        #endregion

    }
}
