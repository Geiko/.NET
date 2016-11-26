namespace TestShipping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Departure = c.String(),
                        Purpose = c.String(),
                        Customer = c.String(),
                        Carrier = c.String(),
                        ScheduledTraffic = c.Double(nullable: false),
                        ActualTraffic = c.Double(nullable: false),
                        Day1Tons = c.Double(),
                        Day2Tons = c.Double(),
                        Day3Tons = c.Double(),
                        Day4Tons = c.Double(),
                        Day5Tons = c.Double(),
                        Day6Tons = c.Double(),
                        Day7Tons = c.Double(),
                        Day8Tons = c.Double(),
                        Day9Tons = c.Double(),
                        Day10Tons = c.Double(),
                        Day11Tons = c.Double(),
                        Day12Tons = c.Double(),
                        Day13Tons = c.Double(),
                        Day14Tons = c.Double(),
                        Day15Tons = c.Double(),
                        Day16Tons = c.Double(),
                        Day17Tons = c.Double(),
                        Day18Tons = c.Double(),
                        Day19Tons = c.Double(),
                        Day20Tons = c.Double(),
                        Day21Tons = c.Double(),
                        Day22Tons = c.Double(),
                        Day23Tons = c.Double(),
                        Day24Tons = c.Double(),
                        Day25Tons = c.Double(),
                        Day26Tons = c.Double(),
                        Day27Tons = c.Double(),
                        Day28Tons = c.Double(),
                        Day29Tons = c.Double(),
                        Day30Tons = c.Double(),
                        Day31Tons = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shippings");
        }
    }
}
