using E_SafetyWorkPermit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace E_SafetyWorkPermit.Controllers
{
    public class AccountController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [HttpPost]
        public JsonResult<VendorRegistrationResponseModel> PostVendorRegistration(VendorRegistrationRequestModel _Model)
        {
            VendorRegistrationResponseModel VendorResponse = new VendorRegistrationResponseModel();
            if (!ModelState.IsValid)
            {
                return null;
            }
            else
            {
               
                
                    var VendorDetail = db.VendorRegister.Add(new VendorRegistration()
                    {

                        FullName = _Model.FullName,
                        Name = _Model.Name,
                        UserName = _Model.UserName,
                        Password = _Model.Password,
                        CreatedDate = _Model.CreatedDate,
                        UpdatedDate = _Model.UpdatedDate,
                        Status = _Model.Status

                    });
                   db.SaveChanges();
                VendorResponse.VendorId = VendorDetail.VendorId;
                VendorResponse.FullName = VendorDetail.FullName;
                VendorResponse.Name = VendorDetail.Name;
                VendorResponse.UserName = VendorDetail.UserName;
                VendorResponse.Password = VendorDetail.Password;
                VendorResponse.CreatedDate = VendorDetail.CreatedDate;
                VendorResponse.UpdatedDate = VendorDetail.UpdatedDate;
                VendorResponse.Status = Convert.ToInt32(VendorDetail.Status);
                }
                return Json(VendorResponse);
            }
        [HttpPost]
        public JsonResult<VendorLoginResponseModel>VendorLogin(VendorLoginRequestModel _Model)
        {
           
            if (!ModelState.IsValid)
            {
                return null;
            }
            else
            {
                var user = db.VendorRegister.Where(a => a.UserName == _Model.UserName && a.Password == _Model.Password).FirstOrDefault();
                if (user!=null)
                {
                    VendorLoginResponseModel _Login=new VendorLoginResponseModel();
                    _Login.VendorId = user.VendorId;
                    _Login.UserName = user.UserName;
                    _Login.Password = user.Password;
                    _Login.Status = user.Status;
                    return Json(_Login);
                }
            }
            return null;
        }

        [HttpPost]
        public JsonResult<DepartmentLoginResponseModel> DepartmentLogin(DepartmentLoginRequestModel _Model)
        {

            if (!ModelState.IsValid)
            {
                return null;
            }
            else
            {
                var user = db.DepartmentRegister.Where(a => a.TokenNo == _Model.TokenNo && a.Password == _Model.Password).FirstOrDefault();
                if (user != null)
                {
                    DepartmentLoginResponseModel _Login = new DepartmentLoginResponseModel();
                    _Login.DepartmentId = user.DepartmentId;
                    _Login.TokenNo = user.TokenNo;
                    _Login.Password = user.Password;
                    return Json(_Login);
                }
            }
            return null;
        }
    }

    }

