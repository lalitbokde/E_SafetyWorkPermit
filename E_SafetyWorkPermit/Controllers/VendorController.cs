using E_SafetyWorkPermit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace E_SafetyWorkPermit.Controllers
{
    public class VendorController : ApiController
    {

        [HttpPost]
        public JsonResult<VendorRegistrationResponseModel> PostVendorRegistration(VendorRegistrationModel _Model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            else
            {
                VendorRegistrationResponseModel Vendor = new VendorRegistrationResponseModel();
                using (var ctx = new E_SafetyWorkPermitEntities())
                {
                 var VendorDetail=ctx.VendorRegistrations.Add(new VendorRegistration()
                    {

                        FullName = _Model.FullName,
                        Name = _Model.Name,
                        UserName = _Model.UserName,
                        Password = _Model.Password,
                        CreatedDate = _Model.CreatedDate,
                        UpdatedDate = _Model.UpdatedDate,
                        Status = _Model.Status

                    });
                    ctx.SaveChanges();
                    Vendor.VendorId = VendorDetail.VenderId;
                    Vendor.FullName = VendorDetail.FullName;
                    Vendor.Name = VendorDetail.Name;
                    Vendor.UserName = VendorDetail.UserName;
                    Vendor.Password = VendorDetail.Password;
                    Vendor.CreatedDate = VendorDetail.CreatedDate;
                    Vendor.UpdatedDate = VendorDetail.UpdatedDate;
                    Vendor.Status =Convert.ToInt32( VendorDetail.Status);
                }
                return Json(Vendor);
            }
        }
        
    }
}
