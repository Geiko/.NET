namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pipes", "Manufacturer", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pipes", "Manufacturer");
        }
    }
}
