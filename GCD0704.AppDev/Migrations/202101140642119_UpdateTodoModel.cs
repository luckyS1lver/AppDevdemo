namespace GCD0704.AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTodoModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todoes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Todoes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "Description", c => c.String());
            AlterColumn("dbo.Todoes", "Name", c => c.String());
        }
    }
}
