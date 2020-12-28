namespace Food.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        UnitsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Inventory = c.Int(nullable: false),
                        HadSold = c.Int(),
                        DisContinued = c.Boolean(),
                        CategoryId = c.Int(),
                        SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        PostalCode = c.String(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(),
                        Account = c.String(),
                        Password = c.String(),
                        TypeMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeMembers", t => t.TypeMemberId)
                .Index(t => t.TypeMemberId);
            
            CreateTable(
                "dbo.TypeMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberTypes_Role",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        TypeMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.TypeMemberId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.TypeMembers", t => t.TypeMemberId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.TypeMemberId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        UnitsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        Shipped = c.Boolean(),
                        ShippedDate = c.DateTime(),
                        HadSold = c.Boolean(),
                        Cancelled = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "TypeMemberId", "dbo.TypeMembers");
            DropForeignKey("dbo.MemberTypes_Role", "TypeMemberId", "dbo.TypeMembers");
            DropForeignKey("dbo.MemberTypes_Role", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.MemberTypes_Role", new[] { "TypeMemberId" });
            DropIndex("dbo.MemberTypes_Role", new[] { "RoleId" });
            DropIndex("dbo.Members", new[] { "TypeMemberId" });
            DropIndex("dbo.Customers", new[] { "MemberId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.MemberTypes_Role");
            DropTable("dbo.TypeMembers");
            DropTable("dbo.Members");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
