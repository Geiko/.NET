namespace TestShipping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shippings", "Departure", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Shippings", "Purpose", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Shippings", "Customer", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Shippings", "Carrier", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shippings", "Carrier", c => c.String());
            AlterColumn("dbo.Shippings", "Customer", c => c.String());
            AlterColumn("dbo.Shippings", "Purpose", c => c.String());
            AlterColumn("dbo.Shippings", "Departure", c => c.String());
        }
    }
}
