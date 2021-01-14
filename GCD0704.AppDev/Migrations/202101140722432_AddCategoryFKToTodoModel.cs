namespace GCD0704.AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryFKToTodoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Todoes", "CategoryId");
            AddForeignKey("dbo.Todoes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Todoes", new[] { "CategoryId" });
            DropColumn("dbo.Todoes", "CategoryId");
        }
    }
}
