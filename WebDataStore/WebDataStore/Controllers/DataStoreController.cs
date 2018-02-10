using DataStoreDB.NHibernate.NHRepositories;
using DataStoreDB.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var dbDocuments = DocumentRepository.GetAll();
        //    var documents = dbDocuments.Select(o => new DocumentViewModel()
        //    {
        //        Id = o.Id,
        //        Name = o.Name,
        //        Author = o.Author,
        //        Date = o.Date,
        //        FilePath = o.FilePath
        //    });
        //    return View(documents);
        //}

        [HttpGet]
        public ActionResult Index(string nameSearch, string sort)
        {
            var dbDocuments = DocumentRepository.SearchByName(nameSearch);
            var documents = dbDocuments.Select(o => new DocumentViewModel()
            {
                Id = o.Id,
                Name = o.Name,
                Author = o.Author,
                Date = o.Date,
                FilePath = o.FilePath
            });

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "name":
                        return View(
                            documents.OrderBy(x => x.Name)
                            );
                    case "author":
                        return View(
                            documents.OrderBy(x => x.Author.Login)
                            );
                    case "date":
                        return View(
                            documents.OrderBy(x => x.Date)
                            );
                }
            }
            return View(documents);
        }

        public ActionResult Open(long id)
        {
            var document = DocumentRepository.Get(id);
            if (System.IO.File.Exists(document.FilePath))
            {
                Process.Start(document.FilePath);
            }
            return RedirectToAction("Index");
        }

        //public ActionResult SortByName(IEnumerable<DocumentViewModel> modelForSort)
        //{

        //    return View();
        //}
    }
}