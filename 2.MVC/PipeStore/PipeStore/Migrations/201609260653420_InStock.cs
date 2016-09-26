namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pipes", "InStock", c => c.Double(nullable: false));
            DropColumn("dbo.Pipes", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pipes", "Weight", c => c.Double(nullable: false));
            DropColumn("dbo.Pipes", "InStock");
        }
    }
}
