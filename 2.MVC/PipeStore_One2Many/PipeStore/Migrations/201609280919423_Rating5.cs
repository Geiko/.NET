namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PipeManufacturers",
                c => new
                    {
                        Pipe_Id = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pipe_Id, t.Manufacturer_Id })
                .ForeignKey("dbo.Pipes", t => t.Pipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id, cascadeDelete: true)
                .Index(t => t.Pipe_Id)
                .Index(t => t.Manufacturer_Id);
            
            DropColumn("dbo.Pipes", "Manufacturer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pipes", "Manufacturer", c => c.String(nullable: false, maxLength: 60));
            DropForeignKey("dbo.PipeManufacturers", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.PipeManufacturers", "Pipe_Id", "dbo.Pipes");
            DropIndex("dbo.PipeManufacturers", new[] { "Manufacturer_Id" });
            DropIndex("dbo.PipeManufacturers", new[] { "Pipe_Id" });
            DropTable("dbo.PipeManufacturers");
            DropTable("dbo.Manufacturers");
        }
    }
}
