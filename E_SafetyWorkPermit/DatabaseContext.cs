using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace E_SafetyWorkPermit.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<VendorRegistration> VendorRegister
        {
            get;set;
        }
        public DbSet<DepartmentRegistration> DepartmentRegister
        {
            get; set;
        }
        public DbSet<DepartmentMaster> DepartmentsMasters
        {
            get; set;
        }
        public DbSet<Feedback> feedbacks
        {
            get; set;
        }
        public DatabaseContext()
            //Reference the name of your connection string ( WebAppCon )  
            : base("DefaultConnection") { }
    }
}