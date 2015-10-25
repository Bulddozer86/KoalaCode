namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_article_table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRole", newName: "RoleUser");
            DropPrimaryKey("dbo.RoleUser");
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Headline = c.String(maxLength: 64),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        DeletedById = c.Int(),
                        DeletedDate = c.DateTime(),
                        UpdatedById = c.Int(),
                        UpdatedDate = c.DateTime(nullable: false),
                        BannedById = c.Int(),
                        BannedDate = c.DateTime(),
                        BannedFor = c.Int(),
                        BanReason = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.BannedById)
                .ForeignKey("dbo.Article", t => t.DeletedById)
                .ForeignKey("dbo.Article", t => t.UpdatedById);
            
            AddColumn("dbo.User", "Article_Id", c => c.Int());
            AddPrimaryKey("dbo.RoleUser", new[] { "Role_Id", "User_Id" });
            AddForeignKey("dbo.User", "BannedById", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "DeletedById", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "UpdatedById", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "Article_Id", "dbo.Article", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Article_Id", "dbo.Article");
            DropForeignKey("dbo.User", "UpdatedById", "dbo.Article");
            DropForeignKey("dbo.Article", "UpdatedById", "dbo.Article");
            DropForeignKey("dbo.User", "DeletedById", "dbo.Article");
            DropForeignKey("dbo.Article", "DeletedById", "dbo.Article");
            DropForeignKey("dbo.User", "BannedById", "dbo.Article");
            DropForeignKey("dbo.Article", "BannedById", "dbo.Article");
            DropPrimaryKey("dbo.RoleUser");
            DropColumn("dbo.User", "Article_Id");
            DropTable("dbo.Article");
            AddPrimaryKey("dbo.RoleUser", new[] { "User_Id", "Role_Id" });
            RenameTable(name: "dbo.RoleUser", newName: "UserRole");
        }
    }
}
