using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Mvc;
using BookKeeperNewJosh.Models;
using BookKeeperNewJosh.Repository;
using BookKeeperNewJosh.DAL;
using System.Web.Security;

namespace BookKeeperNewJosh.Controllers
{
    public class AccountSignInController : Controller
    {
        private readonly GenericUnitOfWork unitofwork = new GenericUnitOfWork();
        BookKeeperEntities context = new BookKeeperEntities();
        // GET: AccountSignIn
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] UserSignIn user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isEmailExist = IsEmailExist(user.email);
                var isStudNoExist = IsStudentNumberExist(user.studentNo);
                if (isEmailExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exists");
                    return View(user);
                }
                else if (isStudNoExist)
                {
                    ModelState.AddModelError("StudentNumberExist", "Student Number already exists");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 

                #endregion

                #region  Password Hashing 
                user.password = Crypto.Hash(user.password);
                user.confirmpassword = Crypto.Hash(user.confirmpassword); //
                #endregion

                User newuser = new User();
                {
                    newuser.studentNo = user.studentNo;
                    newuser.fName = user.fName;
                    newuser.lName = user.lName;
                    newuser.password = user.password;
                    newuser.appealed = false;
                    newuser.isBlacklisted = false;
                    newuser.reported = false;
                    newuser.appealReason = "";
                    newuser.blacklistReason = "";
                    newuser.reportReason = "";
                    newuser.ratingcount = 0;
                    newuser.totalrating = 0;

                }
                #region Save to Database

                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {

            var x = unitofwork.GetRepositoryInstance<User>().GetFirstorDefaultByParameter(a => a.email == emailID);
            return x != null;

        }
        [NonAction]
        public bool IsStudentNumberExist(int studNo)
        {

            var x = unitofwork.GetRepositoryInstance<User>().GetFirstorDefaultByParameter(a => a.studentNo.ToString() == studNo.ToString());
            return x != null;

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserSignIn login, string ReturnUrl = "")
        {
            string message = "";

            {
                var x = unitofwork.GetRepositoryInstance<User>().GetFirstorDefaultByParameter(a => a.studentNo == login.studentNo);

                if (x != null)
                {

                    if (string.Compare(Crypto.Hash(login.password), x.password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.studentNo.ToString(), login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "main");
        }
    }
    
}
