using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_SafetyWorkPermit.Models
{
    
    public class DepartmentRegisterResponseModel
    {
        
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string TokenNo { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}