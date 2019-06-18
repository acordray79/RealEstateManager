namespace RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealEstateBuy",
                c => new
                    {
                        BuyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DateAvail = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        BuyFavorite = c.Boolean(),
                        RealEstatePropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuyId)
                .ForeignKey("dbo.RealEstateProperty", t => t.RealEstatePropertyId, cascadeDelete: true)
                .Index(t => t.RealEstatePropertyId);
            
            CreateTable(
                "dbo.RealEstateProperty",
                c => new
                    {
                        RealEstatePropertyId = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        RealEstatePropertyName = c.String(),
                        ImageLink = c.String(),
                        SquareFootage = c.Int(nullable: false),
                        RealEstateAddress = c.String(),
                        RealEstateCity = c.String(),
                        RealEstateState = c.String(),
                        RealEstateZip = c.Int(nullable: false),
                        PropertyType = c.Int(nullable: false),
                        HasBasement = c.Boolean(nullable: false),
                        HasPool = c.Boolean(nullable: false),
                        Bedroom = c.Int(nullable: false),
                        Bathroom = c.Int(nullable: false),
                        Stories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RealEstatePropertyId);
            
            CreateTable(
                "dbo.RealEstateRent",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Available = c.DateTime(nullable: false),
                        PricePerMonth = c.Double(nullable: false),
                        Description = c.String(),
                        UtilitiesIncluded = c.Boolean(nullable: false),
                        PetsAllowed = c.Boolean(nullable: false),
                        IsRentFavorite = c.Boolean(nullable: false),
                        RealEstatePropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.RealEstateProperty", t => t.RealEstatePropertyId, cascadeDelete: true)
                .Index(t => t.RealEstatePropertyId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.RealEstateRent", "RealEstatePropertyId", "dbo.RealEstateProperty");
            DropForeignKey("dbo.RealEstateBuy", "RealEstatePropertyId", "dbo.RealEstateProperty");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.RealEstateRent", new[] { "RealEstatePropertyId" });
            DropIndex("dbo.RealEstateBuy", new[] { "RealEstatePropertyId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.RealEstateRent");
            DropTable("dbo.RealEstateProperty");
            DropTable("dbo.RealEstateBuy");
        }
    }
}
