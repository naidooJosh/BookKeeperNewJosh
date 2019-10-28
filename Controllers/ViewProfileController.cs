using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  BookKeeperNewJosh.DAL;
using BookKeeperNewJosh.Models;
using BookKeeperNewJosh.Repository;
namespace BookKeeperNewJosh.Controllers
{
    public class ViewProfileController : Controller
    {
        private readonly GenericUnitOfWork unitofwork = new GenericUnitOfWork();
        BookKeeperEntities context = new BookKeeperEntities();
        // GET: ViewProfile
        public ActionResult Index()
        {
            return View();
        }
       // public ActionResult rateUser()
      //  {

        //}
        [HttpGet]
        public ActionResult reportUser(User repUser)
        {
            return View(repUser);
        }
        [HttpPost]
        public ActionResult reportUser(User repUser, string reportreason) 
        {
            
            if (ModelState.IsValid)
            {
                repUser.reported = true;
                repUser.reportReason = reportreason;
                unitofwork.GetRepositoryInstance<User>().Update(repUser);
                unitofwork.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(repUser);
            }
        }
    }
}