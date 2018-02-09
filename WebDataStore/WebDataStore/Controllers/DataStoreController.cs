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
    [Authorize]
    public class DataStoreController : Controller
    {
        #region Protected Members

        protected IDocumentRepository DocumentRepository { get; set; } 

        protected IUserRepository UserRepository { get; set; }

        #endregion

        public DataStoreController()
        {
            DocumentRepository = new NHDocumentRepository();
            UserRepository = new NHUserRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dbDocuments = DocumentRepository.GetAll();
            var documents = dbDocuments.Select(o => new DocumentViewModel()
            {
                Id = o.Id,
                Name = o.Name,
                Author = o.Author,
                Date = o.Date,
                FilePath = o.FilePath
            });
            return View(documents);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Open(string path)
        {
            return View();
        }

        public ActionResult SortByName(string name)
        {
            return View();
        }
    }
}