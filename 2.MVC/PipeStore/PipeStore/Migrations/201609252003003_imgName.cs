namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pipes", "ImageUrl", c => c.String(maxLength: 1024));
            DropColumn("dbo.Pipes", "DiskUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pipes", "DiskUrl", c => c.String(maxLength: 1024));
            DropColumn("dbo.Pipes", "ImageUrl");
        }
    }
}
