namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressDataToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "HouseNumber", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ApartamentNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ApartamentNumber");
            DropColumn("dbo.AspNetUsers", "HouseNumber");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
