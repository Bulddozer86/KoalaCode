namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixarticle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserArticle", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserArticle", "Article_Id", "dbo.Article");
            AddColumn("dbo.Article", "User_Id", c => c.Int());
            AddForeignKey("dbo.Article", "User_Id", "dbo.User", "Id");
            DropTable("dbo.UserArticle");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserArticle",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Article_Id });
            
            DropForeignKey("dbo.Article", "User_Id", "dbo.User");
            DropColumn("dbo.Article", "User_Id");
            AddForeignKey("dbo.UserArticle", "Article_Id", "dbo.Article", "Id");
            AddForeignKey("dbo.UserArticle", "User_Id", "dbo.User", "Id");
        }
    }
}
