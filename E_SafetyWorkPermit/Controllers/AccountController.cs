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
        public async Task<ResponseResultModel> PostVendorRegistration(VendorRegistrationRequestModel _Model)
        {
            try
            {
                VendorRegistrationResponseModel VendorResponse = null;
                if (!ModelState.IsValid)
                {
                    return new ResponseResultModel { Message = "Invalid Detail", Status = 0, Response = null };
                }
                else
                {
                    var CountVendor = db.VendorRegister.Where(a => a.UserName == _Model.UserName).ToList();
                    if (CountVendor.Count > 0)
                    {
                        return new ResponseResultModel { Message = "UserName Already Available", Status = 0, Response = null };
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


                        return new ResponseResultModel { Message = "Success", Status = 1, Response = VendorDetail };
                    }
                }
            }
            catch
            {
                return new ResponseResultModel { Message = "Invalid Detail", Status = 0, Response = null };
            }
            
        }
        [HttpPost]
        public async Task<ResponseResultModel> VendorLogin(VendorLoginRequestModel _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }
                else
                {
                    var user = db.VendorRegister.Where(a => a.UserName == _Model.UserName && a.Password == _Model.Password).FirstOrDefault();
                    VendorLoginResponseModel _Login = new VendorLoginResponseModel();
                    if (user != null)
                    {

                        _Login.VendorId = user.VendorId;
                        _Login.UserName = user.UserName;
                        _Login.Password = user.Password;
                        _Login.Status = user.Status;
                        return new ResponseResultModel { Message = "Successfull.", Status = 1, Response = _Login };
                    }
                }
                return new ResponseResultModel { Message = "invalid username or password.", Status = 0, Response = null };
            }
            catch
            {
                return new ResponseResultModel { Message = "invalid username or password.", Status = 0, Response = null };
            }
        }

        [HttpPost]
        public async Task<ResponseResultModel> DepartmentLogin(DepartmentLoginRequestModel _Model)
        {
            try {
                DepartmentLoginResponseModel _Login = null;
                if (!ModelState.IsValid)
                {
                    return null;
                }
                else
                {
                    var user = db.DepartmentRegister.Where(a => a.TokenNo == _Model.TokenNo && a.Password == _Model.Password).FirstOrDefault();
                    var Login = new DepartmentLoginResponseModel();
                    if (user != null)
                    {

                        Login.DepartmentId = user.DepartmentId;
                        Login.TokenNo = user.TokenNo;
                        Login.Password = user.Password;
                        return new ResponseResultModel { Message = "Successfull", Status = 1, Response = _Login };
                    }
                }
                return new ResponseResultModel { Message = "invalid username or password.", Status = 0, Response = null };
            }
            catch
            {
                return new ResponseResultModel { Message = "invalid username or password.", Status = 0, Response = null };
            }
           }
       
         }

    }

