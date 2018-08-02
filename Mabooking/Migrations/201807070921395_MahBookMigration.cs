namespace Mabooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MahBookMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Flight.Routs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FlightNumber = c.String(),
                        Origin = c.String(),
                        Destination = c.String(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Flight.Schedule",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        FltDate = c.DateTime(nullable: false),
                        FltReg = c.String(),
                        FltCapVol = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FltCapWeight = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Routs_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("Flight.Routs", t => t.Routs_Id, cascadeDelete: true)
                .Index(t => t.Routs_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Flight.Schedule", "Routs_Id", "Flight.Routs");
            DropIndex("Flight.Schedule", new[] { "Routs_Id" });
            DropTable("Flight.Schedule");
            DropTable("Flight.Routs");
        }
    }
}
