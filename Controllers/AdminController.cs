using BookKeeperNewJosh.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKeeperNewJosh.Controllers
{
    public class AdminController : Controller
    {


        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Dashboard()
        {
            return View();
        }


        //* NB PLZ right click the lightbulb of the underlined List, and click "using BookKeeperDAL;"
        public ActionResult Module()
        {
            List<Tbl_Module> allModules = _unitOfWork.GetRepositoryInstance<Tbl_Module>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
        }
    }
}