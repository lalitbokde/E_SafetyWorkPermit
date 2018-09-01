using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_SafetyWorkPermit.Models
{
    public class VendorRegistrationModel
    {
        public long VendorId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

    }
    public class VendorRegistrationResponseModel
    {
        public long VendorId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}