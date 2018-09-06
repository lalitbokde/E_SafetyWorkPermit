using E_SafetyWorkPermit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SafetyWorkPermit.Controllers
{
    public class UpdateDepartmentController : Controller
    {
        DatabaseContext Db = new DatabaseContext();
        // GET: UpdateDepartment
        public ActionResult Index()
        {
            return View();
        }
      
        
      
    }
}