namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        RentalItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Orders_Id = c.Int(),
                        RentalItems_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .ForeignKey("dbo.RentalItems", t => t.RentalItems_Id)
                .Index(t => t.Orders_Id)
                .Index(t => t.RentalItems_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.String(maxLength: 50),
                        OrderName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentalItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ECode = c.String(maxLength: 50),
                        Descriprion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentalItemPieces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalItemsId = c.Int(),
                        Barcode = c.String(maxLength: 50),
                        SerialNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RentalItems", t => t.RentalItemsId)
                .Index(t => t.RentalItemsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalItemPieces", "RentalItemsId", "dbo.RentalItems");
            DropForeignKey("dbo.OrderLines", "RentalItems_Id", "dbo.RentalItems");
            DropForeignKey("dbo.OrderLines", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.RentalItemPieces", new[] { "RentalItemsId" });
            DropIndex("dbo.OrderLines", new[] { "RentalItems_Id" });
            DropIndex("dbo.OrderLines", new[] { "Orders_Id" });
            DropTable("dbo.RentalItemPieces");
            DropTable("dbo.RentalItems");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
        }
    }
}
