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
                        Standard = c.String(nullable: false, maxLength: 60),
                        ReleaseDate = c.DateTime(nullable: false),
                        Material = c.String(nullable: false, maxLength: 60),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pipes");
        }
    }
}
