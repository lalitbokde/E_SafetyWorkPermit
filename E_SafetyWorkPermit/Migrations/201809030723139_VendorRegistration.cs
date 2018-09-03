namespace E_SafetyWorkPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorRegistration : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
