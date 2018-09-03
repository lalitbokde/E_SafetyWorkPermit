using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_SafetyWorkPermit.Models
{
    public class AccountResponseModel
    {
    }
    public class VendorRegistrationResponseModel
    {
        [Key]
        public long VendorId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
    public class VendorRegistrationRequestModel
    {
        [Key]
        public long VendorId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
    public class DepartmentRegistrationViewModel
    {
        [Key]
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string TokenNo { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<DepartmentMasterViewModel> DepartmentList { get; set; }

    }
    public class DepartmentRegistrationResponseModel
    {
        [Key]
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public string TokenNo { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int DepartmentMasterId { get; set; }
        public virtual List<DepartmentMasterViewModel> DepartmentList { get; set; }
    }
    public class DepartmentMasterViewModel
    {
        [Key]
        public long DepartmentMasterId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
    public class DepartmentMasterResponseModel
    {
        [Key]
        public long DepartmentMasterId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}