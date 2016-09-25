namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pipes", "DiskUrl", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pipes", "DiskUrl");
        }
    }
}
