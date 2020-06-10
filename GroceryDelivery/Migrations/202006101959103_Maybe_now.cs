namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maybe_now : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "Quanity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "Quanity");
        }
    }
}
