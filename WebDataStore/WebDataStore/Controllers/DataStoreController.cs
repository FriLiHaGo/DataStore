using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDataStore.Controllers
{
    public class DataStoreController : Controller
    {
        // GET: DataStore
        public ActionResult Index()
        {
            return View();
        }
    }
}