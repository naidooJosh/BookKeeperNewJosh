using BookKeeperNewJosh.Repository;
using BookKeeperNewJosh.DAL;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using BookKeeperNewJosh.Models;

namespace BookKeeperNewJosh.Controllers
{
    public class AdminController : Controller
    {
        private readonly GenericUnitOfWork unitofwork = new GenericUnitOfWork();
        BookKeeperEntities context = new BookKeeperEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var users = unitofwork.GetRepositoryInstance<User>().GetAllRecords();
            return View(users);
        }
        public ActionResult UserDetails(int id)
        {
            var user = unitofwork.GetRepositoryInstance<User>().GetFirstorDefault(id);
            return View(user);
        }
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(Department depart)
        {
            depart.departmentID = unitofwork.GetRepositoryInstance<Department>().GetAllRecordsCount() + 1;
            if (ModelState.IsValid)
            {
                unitofwork.GetRepositoryInstance<Department>().Add(depart);
                unitofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditDepart(int id)
        {
            var Depart = unitofwork.GetRepositoryInstance<Department>().GetFirstorDefault(id);
            return View(Depart);
        }

        [HttpPost]
        public ActionResult EditDepart(Department Depart)
        {
            if (ModelState.IsValid)
            {
                unitofwork.GetRepositoryInstance<Department>().Update(Depart);
                unitofwork.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(Depart);
            }
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            var Depart = unitofwork.GetRepositoryInstance<Department>().GetFirstorDefault(id);
            return View(Depart);
        }

        [HttpPost]
        public ActionResult ConfirmDeleteDepartment(int id)
        {
            unitofwork.GetRepositoryInstance<Department>().Remove(unitofwork.GetRepositoryInstance<Department>().GetFirstorDefault(id));
            unitofwork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult displayReported()
        {
            var reportedUsers = context.Users.SqlQuery("SELECT * FROM dbo.Users WHERE reported = 1").ToList();
           return View(reportedUsers);
        }
        public ActionResult displayAppealed()
        {
            var appealedUsers = context.Users.SqlQuery("SELECT * FROM dbo.Users WHERE appealed = 1").ToList();
            return View(appealedUsers);
        }
        public ActionResult displayRanking()
        {
            var rankingUsers = context.Users.SqlQuery("SELECT * FROM dbo.Users WHERE ratingcount > 1").ToList();
            AdminRankingData adminRanking =  new AdminRankingData();
            adminRanking.top5 = (ArrayList)rankingUsers.OrderBy(x => x.realRating);
            adminRanking.bottom5 = (ArrayList)rankingUsers.OrderByDescending(x => x.realRating);
            adminRanking.averRank = rankingUsers.Average(x => x.realRating);
            return View(adminRanking);
        }
        [HttpGet]
        public ActionResult blacklistUser(int id)
        {
            var user = unitofwork.GetRepositoryInstance<User>().GetFirstorDefault(id);
            return View(user);
        }
       [HttpPost]
       public ActionResult blacklistUser(User user, string reason)
        {
            if (ModelState.IsValid)

            {
                user.isBlacklisted = true;
                user.blacklistReason = reason;
                unitofwork.GetRepositoryInstance<User>().Update(user);
                unitofwork.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult whitelistUser(int id)
        {
            var user = unitofwork.GetRepositoryInstance<User>().GetFirstorDefault(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult whitelistUser(User user, string reason)
        {
            if (ModelState.IsValid)

            {
                user.isBlacklisted = false;
                user.blacklistReason = "";
                unitofwork.GetRepositoryInstance<User>().Update(user);
                unitofwork.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

    }
}  
