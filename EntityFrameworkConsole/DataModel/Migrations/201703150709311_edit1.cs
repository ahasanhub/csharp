namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Stdinfo", newName: "Standards");
            MoveTable(name: "Admin.Standards", newSchema: "dbo");
            MoveTable(name: "Admin.Students", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Students", newSchema: "Admin");
            MoveTable(name: "dbo.Standards", newSchema: "Admin");
            RenameTable(name: "Admin.Standards", newName: "Stdinfo");
        }
    }
}
