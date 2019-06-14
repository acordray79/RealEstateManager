namespace RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RealEstateBuy", "Description", c => c.String());
            AlterColumn("dbo.RealEstateBuy", "BuyFavorite", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RealEstateBuy", "BuyFavorite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.RealEstateBuy", "Description", c => c.String(nullable: false));
        }
    }
}
