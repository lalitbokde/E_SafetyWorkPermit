using E_SafetyWorkPermit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SafetyWorkPermit.Controllers
{
    public class RegistrationController : Controller
    {
        DatabaseContext Db = new DatabaseContext();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterDepartment()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult RegisterDepartment(DepartmentRegistrationViewModel _model)
        {

            return View();
        }
        public JsonResult GetallDepartment()
        {
            DepartmentMasterViewModel dep = new DepartmentMasterViewModel();
            var Department = Db.DepartmentsMasters.ToList();
            foreach (var Departments in Department)
            {
                dep.DepartmentMasterId = Departments.DepartmentMasterId;
                dep.DepartmentName = Departments.DepartmentName;
                dep.DepartmentCode = Departments.DepartmentCode;
                dep.CreatedDate = Departments.CreatedDate;
                dep.UpdatedDate = Departments.UpdatedDate;
            }
            return Json(dep, JsonRequestBehavior.AllowGet);
        }
    }
}