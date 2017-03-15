namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentAddresses", name: "StudentAddressId", newName: "StudentId");
            RenameIndex(table: "dbo.StudentAddresses", name: "IX_StudentAddressId", newName: "IX_StudentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentAddresses", name: "IX_StudentId", newName: "IX_StudentAddressId");
            RenameColumn(table: "dbo.StudentAddresses", name: "StudentId", newName: "StudentAddressId");
        }
    }
}
