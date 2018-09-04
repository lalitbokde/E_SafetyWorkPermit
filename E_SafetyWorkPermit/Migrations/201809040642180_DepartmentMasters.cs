namespace E_SafetyWorkPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentMasters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentRegistrations",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentMasterId = c.Long(nullable: false),
                        TokenNo = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        CreatedDate = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DepartmentMasters",
                c => new
                    {
                        DepartmentMasterId = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentCode = c.String(),
                        CreatedDate = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentMasterId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Excellent = c.Boolean(),
                        Good = c.Boolean(),
                        Average = c.Boolean(),
                        Poor = c.Boolean(),
                        CreateDate = c.DateTime(),
                        FeedbackAbout = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VendorRegistrations",
                c => new
                    {
                        VendorId = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VendorRegistrations");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.DepartmentMasters");
            DropTable("dbo.DepartmentRegistrations");
        }
    }
}
