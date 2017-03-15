namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.Stdinfo",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "Admin.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                        Standard_StandardId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("Admin.Stdinfo", t => t.Standard_StandardId)
                .Index(t => t.Standard_StandardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Admin.Students", "Standard_StandardId", "Admin.Stdinfo");
            DropIndex("Admin.Students", new[] { "Standard_StandardId" });
            DropTable("Admin.Students");
            DropTable("Admin.Stdinfo");
        }
    }
}
