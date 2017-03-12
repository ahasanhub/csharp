namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropColumn("dbo.Products", "CategotyId");
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategotyId");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "CategotyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategotyId");
            AddForeignKey("dbo.Products", "CategotyId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategotyId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategotyId" });
            AlterColumn("dbo.Products", "CategotyId", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            RenameColumn(table: "dbo.Products", name: "CategotyId", newName: "Category_CategoryId");
            AddColumn("dbo.Products", "CategotyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
