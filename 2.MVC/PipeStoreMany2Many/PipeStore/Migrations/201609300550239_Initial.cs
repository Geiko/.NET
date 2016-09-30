namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contacts = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Pipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(nullable: false, maxLength: 60),
                        StandardId = c.Int(),
                        MaterialId = c.Int(),
                        ManufacturerId = c.Int(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Double(nullable: false),
                        ImageUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.Standards", t => t.StandardId)
                .Index(t => t.StandardId)
                .Index(t => t.MaterialId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PipeOrders",
                c => new
                    {
                        Pipe_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pipe_Id, t.Order_Id })
                .ForeignKey("dbo.Pipes", t => t.Pipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Pipe_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pipes", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.PipeOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.PipeOrders", "Pipe_Id", "dbo.Pipes");
            DropForeignKey("dbo.Pipes", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Pipes", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.PipeOrders", new[] { "Order_Id" });
            DropIndex("dbo.PipeOrders", new[] { "Pipe_Id" });
            DropIndex("dbo.Pipes", new[] { "ManufacturerId" });
            DropIndex("dbo.Pipes", new[] { "MaterialId" });
            DropIndex("dbo.Pipes", new[] { "StandardId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.PipeOrders");
            DropTable("dbo.Standards");
            DropTable("dbo.Materials");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Pipes");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
