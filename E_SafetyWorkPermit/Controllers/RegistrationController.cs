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
        public ActionResult AddDepartmentMaster(long? Id=null)
        {
            DepartmentMasterViewModel Dep;
            if (Id != null)
            {
                ViewBag.DMButtonName = "Update";
                var DepartmentData = Db.DepartmentsMasters.Where(a => a.DepartmentMasterId == Id).FirstOrDefault();
                Dep=new DepartmentMasterViewModel(){
                    DepartmentMasterId= DepartmentData.DepartmentMasterId,
                    DepartmentCode= DepartmentData.DepartmentCode,DepartmentName= DepartmentData.DepartmentName,CreatedDate= DepartmentData.CreatedDate
                };
                return View(Dep);
            }
            else
            {
                ViewBag.DMButtonName = "Save";
                Dep = null;
                return View(Dep);
            }
        }
        [HttpPost]
        public ActionResult AddDepartmentMaster(DepartmentMasterViewModel _DepMaster)
        {
            
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Fill Detail Properly";
                TempData["success"] = "0";
            }
            else if(_DepMaster.DepartmentMasterId != 0 && _DepMaster.DepartmentMasterId != null)
            {
                try
                {
                    var departmentMaster = Db.DepartmentsMasters.Where(a => a.DepartmentMasterId == _DepMaster.DepartmentMasterId).FirstOrDefault();
                    departmentMaster.DepartmentName = (_DepMaster.DepartmentName == null) ? departmentMaster.DepartmentName : _DepMaster.DepartmentName;
                    departmentMaster.DepartmentCode = (_DepMaster.DepartmentCode == null) ? departmentMaster.DepartmentCode : _DepMaster.DepartmentCode;
                    departmentMaster.CreatedDate = (_DepMaster.CreatedDate == null) ? departmentMaster.CreatedDate : _DepMaster.CreatedDate;
                    departmentMaster.UpdatedDate = (_DepMaster.CreatedDate == null) ? departmentMaster.CreatedDate : DateTime.UtcNow.ToShortDateString();
                    Db.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Update Successfull";
                    TempData["success"] = "1";
                    ViewBag.DMButtonName = "Save";
                    GetAllDepartment();
                    return View(new DepartmentMasterViewModel());
                }
                catch
                {
                    TempData["msg"] = "Update fail";
                    TempData["success"] = "0";
                    ViewBag.DMButtonName = "Update";
                    return View(_DepMaster);
                }
            }
            else
            {
                try
                {
                    Db.DepartmentsMasters.Add(new DepartmentMaster()
                    {
                        DepartmentName = _DepMaster.DepartmentName,
                        DepartmentCode = _DepMaster.DepartmentCode,
                        CreatedDate = _DepMaster.CreatedDate,
                        UpdatedDate = DateTime.Now.ToString()
                    });
                    Db.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Save Successfull";
                    TempData["success"] = "1";
                    GetAllDepartment();
                    ViewBag.DMButtonName = "Save";
                    return View(new DepartmentMasterViewModel());
                }
                catch
                {
                    TempData["msg"] = "Department Is Not Inserted";
                    TempData["success"] = "0";
                }

            }
            return View(_DepMaster);
        }
        public ActionResult UpdateDepartment()
        {
            List<DepartmentMasterViewModel> dept = new List<DepartmentMasterViewModel>();
            var query = Db.DepartmentsMasters.ToList();
            foreach (var Data in query)
            {

                dept.Add(new DepartmentMasterViewModel { DepartmentName = Data.DepartmentName, DepartmentMasterId = Data.DepartmentMasterId, DepartmentCode = Data.DepartmentCode, CreatedDate = Data.CreatedDate, UpdatedDate = Data.UpdatedDate });
            }
            return View(dept);
        }

        public ActionResult UpdateDepartmentDetail(long id, FormCollection collection)
        {
            DepartmentMasterViewModel Dep = new DepartmentMasterViewModel()
            {
                DepartmentMasterId = id
            };

            return RedirectToAction("AddDepartmentMaster",new { id });
        }


        //Registration Department
        public ActionResult RegisterDepartment()
        {
           
            GetAllDepartment();
            return View();
        }
        public void GetAllDepartment()
        {
            List<DepartmentMasterViewModel> dept = new List<DepartmentMasterViewModel>();
            var query = Db.DepartmentsMasters.ToList();
            if (query.Count() > 0)
            {
                foreach (var v in query)
                {
                    dept.Add(new DepartmentMasterViewModel { DepartmentName = v.DepartmentName, DepartmentMasterId = v.DepartmentMasterId });
                }
            }
            var enumData = from Role e in System.Enum.GetValues(typeof(Role))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.DepartmentEnumList = new SelectList(enumData, "ID", "Name");
            ViewBag.DepartmentsData = dept;
        }
        [HttpPost]
        public ActionResult RegisterDepartmentDetail(DepartmentRegistrationViewModel DepartmentReg)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Fill Detail Properly";
                TempData["success"] = "0";
            }
            else
            {
                try
                {
                    Db.DepartmentRegister.Add(new DepartmentRegistration()
                    {
                        Name = DepartmentReg.Name,
                        DepartmentMasterId = DepartmentReg.DepartmentMasterId,
                        TokenNo = DepartmentReg.TokenNo,
                        Password = DepartmentReg.Password,
                        Role =DepartmentReg.Role,
                        CreatedDate = DepartmentReg.CreatedDate
                    });
                    Db.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "Success";
                    TempData["success"] = "1";
                    GetAllDepartment();
                    return View(new DepartmentRegistrationViewModel());
                }
                catch
                {
                    TempData["msg"] = "Department Detail Is Not Inserted";
                    TempData["success"] = "0";
                }
             
            }
            GetAllDepartment();
            return View(DepartmentReg); 
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