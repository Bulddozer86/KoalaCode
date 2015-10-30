namespace KoalaCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Article", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Article", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Article", "Description", c => c.String());
            AlterColumn("dbo.Article", "ShortDescription", c => c.String());
        }
    }
}
