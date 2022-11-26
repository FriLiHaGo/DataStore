using DataStoreDB.Models;
using DataStoreDB.NHibernate.NHRepositories;
using DataStoreDB.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WebDataStore.Models;

namespace WebDataStore.Controllers
{
    [Authorize]
    public class CreateDocumentController : Controller
    {
        #region Protected Members

        protected IDocumentRepository DocumentRepository { get; set; }

        protected IUserRepository UserRepository { get; set; }

        #endregion

        public CreateDocumentController()
        {
            DocumentRepository = new NHDocumentRepository();
            UserRepository = new NHUserRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateDocumentModel model)
        {
            if (model.File != null && !string.IsNullOrWhiteSpace(model.Name))
            {
                string fileName = System.IO.Path.GetFileName(model.File.FileName);
                string filePath = Server.MapPath("~/Files/"
                    + Regex.Replace(DateTime.Now.ToString(), "[^0-9]", "")
                    + fileName);
                model.File.SaveAs(filePath);

                var document = new Document()
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    Author = UserRepository.GetByLogin(User.Identity.Name),
                    FilePath = filePath
                };

                DocumentRepository.Save(document);

                return RedirectToAction("Index", "DataStore");
            }

            return View("Index");
        }
    }
}