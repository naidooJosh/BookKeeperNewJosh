using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKeeperNewJosh.Controllers
{
    public class PostBookController : Controller
    {
        // GET: PostBook
        public ActionResult PostBook()
        {
            return View();
        }
    }
}