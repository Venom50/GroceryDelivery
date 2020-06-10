namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shopv3Sorry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShopModels", "latidute", c => c.Single(nullable: false));
            AlterColumn("dbo.ShopModels", "longtitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShopModels", "longtitude", c => c.Long(nullable: false));
            AlterColumn("dbo.ShopModels", "latidute", c => c.Long(nullable: false));
        }
    }
}
