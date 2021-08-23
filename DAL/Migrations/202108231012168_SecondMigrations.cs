namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RentalItems", "Descriprion", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentalItems", "Descriprion", c => c.String(maxLength: 50));
        }
    }
}
