namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pipes", "MaterialId", c => c.Int());
            CreateIndex("dbo.Pipes", "MaterialId");
            AddForeignKey("dbo.Pipes", "MaterialId", "dbo.Materials", "Id");
            DropColumn("dbo.Pipes", "Material");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pipes", "Material", c => c.String(nullable: false, maxLength: 60));
            DropForeignKey("dbo.Pipes", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Pipes", new[] { "MaterialId" });
            DropColumn("dbo.Pipes", "MaterialId");
            DropTable("dbo.Materials");
        }
    }
}
