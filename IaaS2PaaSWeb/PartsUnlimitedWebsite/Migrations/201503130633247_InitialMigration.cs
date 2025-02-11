using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PartsUnlimitedWebsite.Migrations
{
    public partial class InitialMigration : Migration
    {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<string>(nullable: true),
                ConcurrencyStamp = table.Column<string>(nullable: true),
                Name = table.Column<string>(nullable: true),
                NormalizedName = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });
            
        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ClaimType = table.Column<string>(nullable: true),
                ClaimValue = table.Column<string>(nullable: true),
                RoleId = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            });
            
        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ClaimType = table.Column<string>(nullable: true),
                ClaimValue = table.Column<string>(nullable: true),
                UserId = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            });
            
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });
            
            migrationBuilder.CreateTable("AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(),
                        RoleId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserRoles", t => new { t.UserId, t.RoleId });
            
            migrationBuilder.CreateTable("AspNetUsers",
                c => new
                    {
                        Id = c.String(),
                        AccessFailedCount = c.Int(nullable: false),
                        ConcurrencyStamp = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        LockoutEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(),
                        Name = c.String(),
                        NormalizedEmail = c.String(),
                        NormalizedUserName = c.String(),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        UserName = c.String()
                    })
                .PrimaryKey("PK_AspNetUsers", t => t.Id);
            
            migrationBuilder.CreateTable("CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_CartItem", t => t.CartItemId);
            
            migrationBuilder.CreateTable("Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Category", t => t.CategoryId);
            
            migrationBuilder.CreateTable("Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        PostalCode = c.String(),
                        State = c.String(),
                        Total = c.Decimal(nullable: false),
                        Username = c.String()
                    })
                .PrimaryKey("PK_Order", t => t.OrderId);
            
            migrationBuilder.CreateTable("OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_OrderDetail", t => t.OrderDetailId);
            
            migrationBuilder.CreateTable("Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false),
                        ProductArtUrl = c.String(),
                        SalePrice = c.Decimal(nullable: false),
                        Title = c.String(),
                        CategoryId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Product", t => t.ProductId);
            
            migrationBuilder.CreateTable("Raincheck",
                c => new
                    {
                        RaincheckId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        StoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Raincheck", t => t.RaincheckId);
            
            migrationBuilder.CreateTable("Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Store", t => t.StoreId);
            
            migrationBuilder.AddForeignKey(
                "AspNetRoleClaims",
                "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                new[] { "RoleId" },
                "AspNetRoles",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserClaims",
                "FK_AspNetUserClaims_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserLogins",
                "FK_AspNetUserLogins_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CartItem",
                "FK_CartItem_Product_ProductId",
                new[] { "ProductId" },
                "Product",
                new[] { "ProductId" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "OrderDetail",
                "FK_OrderDetail_Order_OrderId",
                new[] { "OrderId" },
                "Order",
                new[] { "OrderId" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "OrderDetail",
                "FK_OrderDetail_Product_ProductId",
                new[] { "ProductId" },
                "Product",
                new[] { "ProductId" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Product",
                "FK_Product_Category_CategoryId",
                new[] { "CategoryId" },
                "Category",
                new[] { "CategoryId" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Raincheck",
                "FK_Raincheck_Store_StoreId",
                new[] { "StoreId" },
                "Store",
                new[] { "StoreId" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Raincheck",
                "FK_Raincheck_Product_ProductId",
                new[] { "ProductId" },
                "Product",
                new[] { "ProductId" },
                cascadeDelete: false);
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("AspNetRoleClaims", "FK_AspNetRoleClaims_AspNetRoles_RoleId");
            
            migrationBuilder.DropForeignKey("AspNetUserClaims", "FK_AspNetUserClaims_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("AspNetUserLogins", "FK_AspNetUserLogins_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("Product", "FK_Product_Category_CategoryId");
            
            migrationBuilder.DropForeignKey("OrderDetail", "FK_OrderDetail_Order_OrderId");
            
            migrationBuilder.DropForeignKey("CartItem", "FK_CartItem_Product_ProductId");
            
            migrationBuilder.DropForeignKey("OrderDetail", "FK_OrderDetail_Product_ProductId");
            
            migrationBuilder.DropForeignKey("Raincheck", "FK_Raincheck_Product_ProductId");
            
            migrationBuilder.DropForeignKey("Raincheck", "FK_Raincheck_Store_StoreId");
            
            migrationBuilder.DropTable("AspNetRoles");
            
            migrationBuilder.DropTable("AspNetRoleClaims");
            
            migrationBuilder.DropTable("AspNetUserClaims");
            
            migrationBuilder.DropTable("AspNetUserLogins");
            
            migrationBuilder.DropTable("AspNetUserRoles");
            
            migrationBuilder.DropTable("AspNetUsers");
            
            migrationBuilder.DropTable("CartItem");
            
            migrationBuilder.DropTable("Category");
            
            migrationBuilder.DropTable("Order");
            
            migrationBuilder.DropTable("OrderDetail");
            
            migrationBuilder.DropTable("Product");
            
            migrationBuilder.DropTable("Raincheck");
            
            migrationBuilder.DropTable("Store");
        }
    }
}