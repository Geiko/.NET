namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PipeStandards", newName: "Standards");
            DropForeignKey("dbo.PipeManufacturers", "Pipe_Id", "dbo.Pipes");
            DropForeignKey("dbo.PipeManufacturers", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.PipeManufacturers", new[] { "Pipe_Id" });
            DropIndex("dbo.PipeManufacturers", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.Pipes", name: "PipeStandardId", newName: "StandardId");
            RenameIndex(table: "dbo.Pipes", name: "IX_PipeStandardId", newName: "IX_StandardId");
            AddColumn("dbo.Pipes", "ManufacturerId", c => c.Int());
            CreateIndex("dbo.Pipes", "ManufacturerId");
            AddForeignKey("dbo.Pipes", "ManufacturerId", "dbo.Manufacturers", "Id");
            DropTable("dbo.PipeManufacturers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PipeManufacturers",
                c => new
                    {
                        Pipe_Id = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pipe_Id, t.Manufacturer_Id });
            
            DropForeignKey("dbo.Pipes", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Pipes", new[] { "ManufacturerId" });
            DropColumn("dbo.Pipes", "ManufacturerId");
            RenameIndex(table: "dbo.Pipes", name: "IX_StandardId", newName: "IX_PipeStandardId");
            RenameColumn(table: "dbo.Pipes", name: "StandardId", newName: "PipeStandardId");
            CreateIndex("dbo.PipeManufacturers", "Manufacturer_Id");
            CreateIndex("dbo.PipeManufacturers", "Pipe_Id");
            AddForeignKey("dbo.PipeManufacturers", "Manufacturer_Id", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PipeManufacturers", "Pipe_Id", "dbo.Pipes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Standards", newName: "PipeStandards");
        }
    }
}
