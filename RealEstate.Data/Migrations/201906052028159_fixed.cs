namespace RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _fixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RealEstateRent", "Available", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RealEstateRent", "Available", c => c.DateTime(nullable: false));
        }
    }
}
