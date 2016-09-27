namespace PipeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pipes", name: "StandardId", newName: "PipeStandardId");
            RenameIndex(table: "dbo.Pipes", name: "IX_StandardId", newName: "IX_PipeStandardId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Pipes", name: "IX_PipeStandardId", newName: "IX_StandardId");
            RenameColumn(table: "dbo.Pipes", name: "PipeStandardId", newName: "StandardId");
        }
    }
}
