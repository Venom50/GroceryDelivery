namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreditCardToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreditCard", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreditCard");
        }
    }
}
