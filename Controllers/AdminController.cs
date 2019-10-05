using BookKeeperNewJosh.DAL;
using BookKeeperNewJosh.Repository;
using Newtonsoft.Json;
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
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Department()
        {
            List<Department> alldepartments = _unitOfWork.GetRepositoryInstance<Department>().GetAllRecordsIQueryable().ToList();
            return View(alldepartments);
        }
        public ActionResult AddDept()
        {
            return UpdateDept(0);
        }

        public ActionResult UpdateDept(int DeptId)
        {
            Department department;
                if(DeptId != null)
            {
                department = JsonConvert.DeserializeObject<Department>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Department>().GetFirstorDefault(DeptId)));
            }
                else
            {
                department = new Department();
            }
            return View("UpdateDept", department);
        }
    }
}