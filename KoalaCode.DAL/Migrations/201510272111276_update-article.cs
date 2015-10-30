namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatearticle : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleUser", newName: "UserRole");
            DropForeignKey("dbo.Article", "BannedById", "dbo.Article");
            DropForeignKey("dbo.User", "BannedById", "dbo.Article");
            DropForeignKey("dbo.Article", "DeletedById", "dbo.Article");
            DropForeignKey("dbo.User", "DeletedById", "dbo.Article");
            DropForeignKey("dbo.Article", "UpdatedById", "dbo.Article");
            DropForeignKey("dbo.User", "UpdatedById", "dbo.Article");
            DropForeignKey("dbo.User", "Article_Id", "dbo.Article");
            DropPrimaryKey("dbo.UserRole");
            AddColumn("dbo.Article", "User_Id", c => c.Int());
            AddPrimaryKey("dbo.UserRole", new[] { "User_Id", "Role_Id" });
            AddForeignKey("dbo.Article", "User_Id", "dbo.User", "Id");
            DropColumn("dbo.Article", "DeletedById");
            DropColumn("dbo.Article", "DeletedDate");
            DropColumn("dbo.Article", "UpdatedById");
            DropColumn("dbo.Article", "BannedById");
            DropColumn("dbo.Article", "BannedDate");
            DropColumn("dbo.Article", "BannedFor");
            DropColumn("dbo.Article", "BanReason");
            DropColumn("dbo.User", "Article_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Article_Id", c => c.Int());
            AddColumn("dbo.Article", "BanReason", c => c.String(maxLength: 1024));
            AddColumn("dbo.Article", "BannedFor", c => c.Int());
            AddColumn("dbo.Article", "BannedDate", c => c.DateTime());
            AddColumn("dbo.Article", "BannedById", c => c.Int());
            AddColumn("dbo.Article", "UpdatedById", c => c.Int());
            AddColumn("dbo.Article", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.Article", "DeletedById", c => c.Int());
            DropForeignKey("dbo.Article", "User_Id", "dbo.User");
            DropPrimaryKey("dbo.UserRole");
            DropColumn("dbo.Article", "User_Id");
            AddPrimaryKey("dbo.UserRole", new[] { "Role_Id", "User_Id" });
            AddForeignKey("dbo.User", "Article_Id", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "UpdatedById", "dbo.Article", "Id");
            AddForeignKey("dbo.Article", "UpdatedById", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "DeletedById", "dbo.Article", "Id");
            AddForeignKey("dbo.Article", "DeletedById", "dbo.Article", "Id");
            AddForeignKey("dbo.User", "BannedById", "dbo.Article", "Id");
            AddForeignKey("dbo.Article", "BannedById", "dbo.Article", "Id");
            RenameTable(name: "dbo.UserRole", newName: "RoleUser");
        }
    }
}
