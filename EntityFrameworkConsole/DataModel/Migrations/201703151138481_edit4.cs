namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Standardinfo", newName: "Standards");
            RenameTable(name: "dbo.StudentInfo", newName: "Students");
            DropForeignKey("dbo.StudentInfoDetail", "StudentID", "dbo.StudentInfo");
            DropIndex("dbo.StudentInfoDetail", new[] { "StudentID" });
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        StudentAddressId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.StudentAddressId)
                .ForeignKey("dbo.Students", t => t.StudentAddressId)
                .Index(t => t.StudentAddressId);
            
            DropTable("dbo.StudentInfoDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentInfoDetail",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            DropForeignKey("dbo.StudentAddresses", "StudentAddressId", "dbo.Students");
            DropIndex("dbo.StudentAddresses", new[] { "StudentAddressId" });
            DropTable("dbo.StudentAddresses");
            CreateIndex("dbo.StudentInfoDetail", "StudentID");
            AddForeignKey("dbo.StudentInfoDetail", "StudentID", "dbo.StudentInfo", "StudentID");
            RenameTable(name: "dbo.Students", newName: "StudentInfo");
            RenameTable(name: "dbo.Standards", newName: "Standardinfo");
        }
    }
}
