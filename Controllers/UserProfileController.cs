using BookKeeperNewJosh.DAL;
using BookKeeperNewJosh.Models;
using BookKeeperNewJosh.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookKeeperNewJosh.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly GenericUnitOfWork unitofwork = new GenericUnitOfWork();
        BookKeeperEntities context = new BookKeeperEntities();
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Edit()
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            User user = context.Users.FirstOrDefault(u => u.studentNo.Equals(username));

            // Construct the viewmodel
            UserProfileEdit model = new UserProfileEdit();
            model.fName = user.fName;
            model.lName = user.lName;
            model.email = user.email;
            model.totalrating = user.totalrating;
            model.Departments = user.Departments;
            MultiSelectList departments = new MultiSelectList(unitofwork.GetRepositoryInstance<User>().GetFirstorDefaultByParameter(u => u.studentNo.Equals(username)).Departments);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfileEdit userprofile)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                User user = unitofwork.GetRepositoryInstance<User>().GetFirstorDefaultByParameter(u => u.studentNo.Equals(username));
                //User user = context.Users.FirstOrDefault(u => u.studentNo.Equals(username));

                // Update fields
                userprofile.fName = user.fName;
                userprofile.lName = user.lName;
                userprofile.email = user.email;

                unitofwork.GetRepositoryInstance<User>().Update(user);

               // context.Entry(user).State = EntityState.Modified;

               //db.SaveChanges();

                return RedirectToAction("Index", "Home"); // or whatever
            }

            return View(userprofile);
        }

        
    }
}