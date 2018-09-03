namespace E_SafetyWorkPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentsMasters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentRegistrations",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Department = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DepartmentMasters");
            DropTable("dbo.DepartmentRegistrations");
        }
    }
}
