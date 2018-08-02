namespace Mabooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mabookingmigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Flight.Reserv",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(nullable: false),
                        FlightsSchedule_Id = c.Long(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pcs = c.Int(nullable: false),
                        ULD = c.String(),
                        Description = c.String(),
                        UserName = c.Int(nullable: false),
                        Canceled = c.Boolean(nullable: false),
                        RequestedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("Flight.Schedule", t => t.FlightsSchedule_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.FlightsSchedule_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Mobile = c.String(),
                        AgentName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Flight.Reserv", "FlightsSchedule_Id", "Flight.Schedule");
            DropForeignKey("Flight.Reserv", "Customer_Id", "dbo.Customers");
            DropIndex("Flight.Reserv", new[] { "FlightsSchedule_Id" });
            DropIndex("Flight.Reserv", new[] { "Customer_Id" });
            DropTable("dbo.Customers");
            DropTable("Flight.Reserv");
        }
    }
}
