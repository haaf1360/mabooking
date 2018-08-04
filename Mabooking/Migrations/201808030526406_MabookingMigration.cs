namespace Mabooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MabookingMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Flight.Reserv", "Customer_Id", "dbo.Customers");
            DropIndex("Flight.Reserv", new[] { "Customer_Id" });
            DropPrimaryKey("Flight.Reserv");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("Flight.Reserv", "id", c => c.Long(nullable: false, identity: true));
            AlterColumn("Flight.Reserv", "Customer_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("Flight.Reserv", "id");
            AddPrimaryKey("dbo.Customers", "Id");
            CreateIndex("Flight.Reserv", "Customer_Id");
            AddForeignKey("Flight.Reserv", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Flight.Reserv", "Customer_Id", "dbo.Customers");
            DropIndex("Flight.Reserv", new[] { "Customer_Id" });
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("Flight.Reserv");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("Flight.Reserv", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("Flight.Reserv", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("Flight.Reserv", "id");
            CreateIndex("Flight.Reserv", "Customer_Id");
            AddForeignKey("Flight.Reserv", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
