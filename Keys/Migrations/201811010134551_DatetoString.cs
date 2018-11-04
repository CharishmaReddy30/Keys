namespace Keys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSolds", "DateSold", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
        }
    }
}
