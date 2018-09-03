namespace E_SafetyWorkPermit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentMasters", "DepartmentRegistration_DepartmentId", "dbo.DepartmentRegistrations");
            DropIndex("dbo.DepartmentMasters", new[] { "DepartmentRegistration_DepartmentId" });
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
            
            DropColumn("dbo.DepartmentMasters", "DepartmentRegistration_DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DepartmentMasters", "DepartmentRegistration_DepartmentId", c => c.Long());
            DropTable("dbo.Feedbacks");
            CreateIndex("dbo.DepartmentMasters", "DepartmentRegistration_DepartmentId");
            AddForeignKey("dbo.DepartmentMasters", "DepartmentRegistration_DepartmentId", "dbo.DepartmentRegistrations", "DepartmentId");
        }
    }
}
