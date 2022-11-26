using DataStoreDB.NHibernate.NHRepositories;
using DataStoreDB.Repositories;
using System.Diagnostics;
using System.Linq;
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
        public ActionResult Index(string search, string sort)
        {
            var dbDocuments = DocumentRepository.SearchByName(search);
            var documents = dbDocuments.Select(o => new DocumentViewModel()
            {
                Id = o.Id,
                Name = o.Name,
                Author = o.Author,
                Date = o.Date,
                FilePath = o.FilePath
            });

            ViewBag.SortByName = string.IsNullOrWhiteSpace(sort) ? "descending name" : "";
            ViewBag.SortByAuthor = sort == "author" ? "descending author" : "author";
            ViewBag.SortByDate = sort == "date" ? "descending date" : "date";

            switch (sort)
            {
                case "descending author":
                    return View(documents.OrderByDescending(x => x.Author.Login));
                case "author":
                    return View(documents.OrderBy(x => x.Author.Login));
                case "descending date":
                    return View(documents.OrderByDescending(x => x.Date));
                case "date":
                    return View(documents.OrderBy(x => x.Date));
                case "descending name":
                    return View(documents.OrderByDescending(x => x.Name));
                default:
                    return View(documents.OrderBy(x => x.Name));
            }
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
    }
}