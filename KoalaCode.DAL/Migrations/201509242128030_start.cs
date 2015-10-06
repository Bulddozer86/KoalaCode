namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        FullName = c.String(),
                        Description = c.String(),
                        Karma = c.Int(nullable: false),
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
                .ForeignKey("dbo.User", t => t.BannedById)
                .ForeignKey("dbo.User", t => t.DeletedById)
                .ForeignKey("dbo.User", t => t.UpdatedById)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.Role", t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UpdatedById", "dbo.User");
            DropForeignKey("dbo.UserRole", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.UserRole", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "DeletedById", "dbo.User");
            DropForeignKey("dbo.User", "BannedById", "dbo.User");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "Login" });
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
