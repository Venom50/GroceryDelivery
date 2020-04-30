namespace GroceryDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3464a3f1-f88e-4339-99f2-8fb75bdc2ea9', N'guest@grocerydelivery.com', 0, N'AMOrYP96ONLlkKO8EIHePi1YzwqPuKUYgDimqRPmu3R+iy8ObJlHqIf33h2VptlpRw==', N'bc4df924-f0d7-4f99-ae67-a406b92c5552', NULL, 0, 0, NULL, 1, 0, N'guest@grocerydelivery.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72c364ea-560e-4e20-b422-167cc4a83613', N'admin@grocerydelivery.com', 0, N'AMdv9jJ1GAzd85fqHT3hwXqzo7qPBHRefe9KiCDJV1RwZSwb9tHe3LvowesBFHg12w==', N'5ec29885-a6e7-472f-9ccf-41883a53da01', NULL, 0, 0, NULL, 1, 0, N'admin@grocerydelivery.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0a8e5bc-fce4-4291-b172-13ac084cfa11', N'IsAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72c364ea-560e-4e20-b422-167cc4a83613', N'b0a8e5bc-fce4-4291-b172-13ac084cfa11')

");
        }
        
        public override void Down()
        {
        }
    }
}
