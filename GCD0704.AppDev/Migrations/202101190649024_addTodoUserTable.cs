namespace GCD0704.AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTodoUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TodoId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Todoes", t => t.TodoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TodoId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TodoUsers", "TodoId", "dbo.Todoes");
            DropIndex("dbo.TodoUsers", new[] { "UserId" });
            DropIndex("dbo.TodoUsers", new[] { "TodoId" });
            DropTable("dbo.TodoUsers");
        }
    }
}
