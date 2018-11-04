namespace Keys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsDeleted");
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Stores", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
