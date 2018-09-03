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
        }

    }

