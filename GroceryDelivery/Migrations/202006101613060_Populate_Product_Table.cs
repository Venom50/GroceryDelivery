namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_Product_Table : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ProductModels ON");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (1,'Chleb z Biedry',2.50,1)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (2,'Mleko ze Stonki',3.00,1)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (3,'Szynka z Owada',9.50,1)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (4,'Polskie Maslo z Hiszpani',4.0,1)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (5,'Alba Komunijna Kremowa',21.37,1)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (6,'Chleb z Lidla',2.60,2)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (7,'Mleko od Niemca',3.10,2)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (8,'Piwo smaczniutkie',3.69,2)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (9,'Oglr od Henia',0.60,2)");
            Sql("INSERT INTO ProductModels (Id, Name, Price, Shop) VALUES (10,'Ryba co juz nie plywa',12.20,2)");
            Sql("SET IDENTITY_INSERT ProductModels OFF");
        }
        
        public override void Down()
        {
        }
    }
}
