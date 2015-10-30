namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateforerticles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRole", newName: "RoleUser");
            DropForeignKey("dbo.Article", "User_Id", "dbo.User");
            DropPrimaryKey("dbo.RoleUser");
            CreateTable(
                "dbo.UserArticle",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Article_Id })
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.Article", t => t.Article_Id);
            
            AddPrimaryKey("dbo.RoleUser", new[] { "Role_Id", "User_Id" });
            DropColumn("dbo.Article", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Article", "User_Id", c => c.Int());
            DropForeignKey("dbo.UserArticle", "Article_Id", "dbo.Article");
            DropForeignKey("dbo.UserArticle", "User_Id", "dbo.User");
            DropPrimaryKey("dbo.RoleUser");
            DropTable("dbo.UserArticle");
            AddPrimaryKey("dbo.RoleUser", new[] { "User_Id", "Role_Id" });
            AddForeignKey("dbo.Article", "User_Id", "dbo.User", "Id");
            RenameTable(name: "dbo.RoleUser", newName: "UserRole");
        }
    }
}
