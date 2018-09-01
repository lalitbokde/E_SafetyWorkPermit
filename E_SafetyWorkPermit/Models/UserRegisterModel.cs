using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_SafetyWorkPermit.Models
{
    public class UserRegisterModel
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
    public class UserRegisterResponseModel
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}