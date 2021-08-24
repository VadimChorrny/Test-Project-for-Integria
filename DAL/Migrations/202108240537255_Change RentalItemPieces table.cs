namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRentalItemPiecestable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RentalItemPieces", new[] { "RentalItemsId" });
            RenameColumn(table: "dbo.RentalItems", name: "RentalItemsId", newName: "RentalItemPieces_Id");
            CreateIndex("dbo.RentalItems", "RentalItemPieces_Id");
            DropColumn("dbo.RentalItemPieces", "RentalItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentalItemPieces", "RentalItemsId", c => c.Int());
            DropIndex("dbo.RentalItems", new[] { "RentalItemPieces_Id" });
            RenameColumn(table: "dbo.RentalItems", name: "RentalItemPieces_Id", newName: "RentalItemsId");
            CreateIndex("dbo.RentalItemPieces", "RentalItemsId");
        }
    }
}
