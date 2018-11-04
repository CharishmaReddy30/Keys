namespace Keys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassSales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSolds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSolds", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ProductSolds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductSolds", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ProductSolds", new[] { "StoreId" });
            DropIndex("dbo.ProductSolds", new[] { "CustomerId" });
            DropIndex("dbo.ProductSolds", new[] { "ProductId" });
            DropTable("dbo.ProductSolds");
        }
    }
}
