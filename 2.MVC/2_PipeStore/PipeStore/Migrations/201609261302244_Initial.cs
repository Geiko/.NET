namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Size = c.String(nullable: false, maxLength: 60),
                        StandardId = c.Int(),
                        Manufacturer = c.String(nullable: false, maxLength: 60),
                        ReleaseDate = c.DateTime(nullable: false),
                        Material = c.String(nullable: false, maxLength: 60),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Double(nullable: false),
                        ImageUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Standards", t => t.StandardId)
                .Index(t => t.StandardId);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pipes", "StandardId", "dbo.Standards");
            DropIndex("dbo.Pipes", new[] { "StandardId" });
            DropTable("dbo.Standards");
            DropTable("dbo.Pipes");
        }
    }
}
