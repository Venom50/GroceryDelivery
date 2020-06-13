namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreProducts : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ProductModels ON");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (11, 'Jogurt z Tesco', 1.80, 3)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (12, 'Papier toaletowy firmy Dupny', 8.20, 3)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (13, 'Zupka chińska', 2.00, 3)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (14, 'Płatki śniadaniowe Pyszne', 9.00, 3)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (15, 'Kasza mannna', 1.20, 3)");

            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (16, 'Ciastka z Netto', 2.30, 4)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (17, 'Kiełbasa z dzika', 5.60, 4)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (18, 'Kabanos z konia', 2.10, 4)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (19, 'Czekolada Pyszna Biała', 3.40, 4)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (20, 'Sok z arbuza', 2.69, 4)");
            Sql("SET IDENTITY_INSERT ProductModels OFF");
        }
        
        public override void Down()
        {
        }
    }
}
