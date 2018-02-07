using DataStoreDB.NHibernate.NHRepositories;
using DataStoreDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDataStore.Models;

namespace WebDataStore.Controllers
{
    public class AccountController : Controller
    {
        #region Protected Members

        protected IUserRepository UserRepository { get; set; }

        #endregion

        public AccountController()
        {
            UserRepository = new NHUserRepository();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (UserRepository.Check(loginModel.Login, loginModel.Password))
            {
                // аутентификация
                FormsAuthentication.SetAuthCookie(loginModel.Login, true);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public void Logoff()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}