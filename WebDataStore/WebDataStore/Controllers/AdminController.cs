using DataStoreDB.Models;
using DataStoreDB.NHibernate.NHRepositories;
using DataStoreDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDataStore.Models;

namespace WebDataStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region Protected Members

        protected IUserRepository UserRepository { get; set; }

        protected IRoleRepository RoleRepository { get; set; }

        #endregion

        public AdminController()
        {
            UserRepository = new NHUserRepository();
            RoleRepository = new NHRoleRepository();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var users = UserRepository.GetAll()
                .Where(u => u.Status != UserStatus.Deleted);
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var nonUniq = UserRepository.GetAll()
                    .Any(u => u.Login == model.Login);

                if (nonUniq)
                {
                    ModelState.AddModelError("", "Такой логин уже занят");
                    return View();
                }

                var user = new User()
                {
                    Name = model.Name,
                    Sername = model.Sername,
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password,
                    Status = UserStatus.Active,
                    Role = RoleRepository.GetByName("User")
                };
                UserRepository.Save(user);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Ban(long id)
        {
            var user = UserRepository.Get(id);
            if (user == null)
                return new JsonResult()
                {
                    Data = new
                    {
                        success = false,
                        error = "Операция не возможна"
                    }
                };

            user.Status = user.Status == UserStatus.Active
                ? UserStatus.Blocked
                : UserStatus.Active;
            UserRepository.Save(user);

            return new JsonResult()
            {
                Data = new
                {
                    success = true,
                    message = user.Status == UserStatus.Active ? "Забанить" : "Разбанить"
                }
            };
        }

        public ActionResult Delete(long id)
        {
            var user = UserRepository.Get(id);
            if (user == null)
                return RedirectToAction("Index");

            user.Status = UserStatus.Deleted;
            UserRepository.Save(user);

            return RedirectToAction("Index");
        }
    }
}