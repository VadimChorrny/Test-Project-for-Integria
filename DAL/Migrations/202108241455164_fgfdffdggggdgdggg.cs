namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgfdffdggggdgdggg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.String(maxLength: 50),
                        OrderName = c.String(maxLength: 50),
                        OrderLines_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderLines", t => t.OrderLines_Id)
                .Index(t => t.OrderLines_Id);
            
            CreateTable(
                "dbo.RentalItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ECode = c.String(maxLength: 50),
                        Descriprion = c.String(maxLength: 100),
                        RentalItemPiecesId = c.Int(),
                        OrderLines_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RentalItemPieces", t => t.RentalItemPiecesId)
                .ForeignKey("dbo.OrderLines", t => t.OrderLines_Id)
                .Index(t => t.RentalItemPiecesId)
                .Index(t => t.OrderLines_Id);
            
            CreateTable(
                "dbo.RentalItemPieces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(maxLength: 50),
                        SerialNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalItems", "OrderLines_Id", "dbo.OrderLines");
            DropForeignKey("dbo.RentalItems", "RentalItemPiecesId", "dbo.RentalItemPieces");
            DropForeignKey("dbo.Orders", "OrderLines_Id", "dbo.OrderLines");
            DropIndex("dbo.RentalItems", new[] { "OrderLines_Id" });
            DropIndex("dbo.RentalItems", new[] { "RentalItemPiecesId" });
            DropIndex("dbo.Orders", new[] { "OrderLines_Id" });
            DropTable("dbo.RentalItemPieces");
            DropTable("dbo.RentalItems");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
        }
    }
}
