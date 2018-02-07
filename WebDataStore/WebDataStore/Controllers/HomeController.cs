using DataStoreDB.Models;
using DataStoreDB.NHibernate.NHRepositories;
using System.Web.Mvc;

namespace WebDataStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var documentRepository = new NHBaseRepository<Document>();
            //var userRepository = new NHBaseRepository<User>();

            //var document = new Document()
            //{
            //    Name = "Артемист Фаул",
            //    Author = userRepository.Get(1),
            //    Date = DateTime.Now,
            //    FileBin = new Byte[] { 1, 2 }
            //};

            //documentRepository.Save(document);

            //documentRepository.Delete(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}