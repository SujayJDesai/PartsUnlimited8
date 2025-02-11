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
                        UserId = c.Column<string>(nullable: true),
                        RoleId = c.Column<string>(nullable: true)
                    })
                .PrimaryKey("PK_AspNetUserRoles", t => new { t.UserId, t.RoleId });
            
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                })
                .PrimaryKey("PK_CartItem", t => t.CartItemId);
            
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });
            
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });
            
            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                });
            
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductArtUrl = table.Column<string>(nullable: true),
                    SalePrice = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });
            
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