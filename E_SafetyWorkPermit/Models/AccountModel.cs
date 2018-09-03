using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_SafetyWorkPermit.Models
{
    public class VendorRegistration
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
    public class DepartmentRegistration
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
       
    }
    public class DepartmentMaster
    {
        [Key]
        public long DepartmentMasterId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }

    public partial class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Excellent { get; set; }
        public Nullable<bool> Good { get; set; }
        public Nullable<bool> Average { get; set; }
        public Nullable<bool> Poor { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string FeedbackAbout { get; set; }
    }

}