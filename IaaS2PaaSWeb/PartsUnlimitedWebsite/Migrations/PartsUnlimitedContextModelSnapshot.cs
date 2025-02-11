using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PartsUnlimited.Models;
using System;

namespace PartsUnlimitedWebsite.Migrations
{
    [DbContext(typeof(PartsUnlimitedContext))]
    partial class PartsUnlimitedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

                modelBuilder.Entity("Microsoft.AspNet.Identity.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .IsConcurrencyToken();
                        b.Property<string>("Id")
                            .ValueGeneratedOnAdd();
                        b.Property<string>("Name");
                        b.Property<string>("NormalizedName");
                        b.HasKey("Id");
                        b.ToTable("AspNetRoles");
                    });
                
                modelBuilder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .ValueGeneratedOnAdd();
                        b.Property<string>("RoleId");
                        b.HasKey("Id");
                        b.ToTable("AspNetRoleClaims");
                    });
                
                modelBuilder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .ValueGeneratedOnAdd();
                        b.Property<string>("UserId");
                        b.HasKey("Id");
                        b.ToTable("AspNetUserClaims");
                    });
                
                modelBuilder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]", b =>
                    {
                        b.Property<string>("LoginProvider");
                        b.Property<string>("ProviderDisplayName");
                        b.Property<string>("ProviderKey");
                        b.Property<string>("UserId");
                        b.HasKey("LoginProvider", "ProviderKey");
                        b.ToTable("AspNetUserLogins");
                    });
                
                modelBuilder.Entity("Microsoft.AspNet.Identity.IdentityUserRole`1[[System.String, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]", b =>
                    {
                        b.Property<string>("RoleId");
                        b.Property<string>("UserId");
                        b.HasKey("UserId", "RoleId");
                        b.ToTable("AspNetUserRoles");
                    });
                
                modelBuilder.Entity("PartsUnlimited.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount");
                        b.Property<string>("ConcurrencyStamp")
                            .IsConcurrencyToken();
                        b.Property<string>("Email");
                        b.Property<bool>("EmailConfirmed");
                        b.Property<string>("Id")
                            .ValueGeneratedOnAdd();
                        b.Property<bool>("LockoutEnabled");
                        b.Property<DateTimeOffset?>("LockoutEnd");
                        b.Property<string>("Name");
                        b.Property<string>("NormalizedEmail");
                        b.Property<string>("NormalizedUserName");
                        b.Property<string>("PasswordHash");
                        b.Property<string>("PhoneNumber");
                        b.Property<bool>("PhoneNumberConfirmed");
                        b.Property<string>("SecurityStamp");
                        b.Property<bool>("TwoFactorEnabled");
                        b.Property<string>("UserName");
                        b.HasKey("Id");
                        b.ToTable("AspNetUsers");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.CartItem", b =>
                    {
                        b.Property<string>("CartId");
                        b.Property<int>("CartItemId")
                            .ValueGeneratedOnAdd();
                        b.Property<int>("Count");
                        b.Property<DateTime>("DateCreated");
                        b.Property<int>("ProductId");
                        b.HasKey("CartItemId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.Category", b =>
                    {
                        b.Property<int>("CategoryId")
                            .ValueGeneratedOnAdd();
                        b.Property<string>("Description");
                        b.Property<string>("Name");
                        b.HasKey("CategoryId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.Order", b =>
                    {
                        b.Property<string>("Address");
                        b.Property<string>("City");
                        b.Property<string>("Country");
                        b.Property<string>("Email");
                        b.Property<string>("Name");
                        b.Property<DateTime>("OrderDate");
                        b.Property<int>("OrderId")
                            .ValueGeneratedOnAdd();
                        b.Property<string>("Phone");
                        b.Property<string>("PostalCode");
                        b.Property<string>("State");
                        b.Property<decimal>("Total");
                        b.Property<string>("Username");
                        b.HasKey("OrderId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.OrderDetail", b =>
                    {
                        b.Property<int>("OrderDetailId")
                            .ValueGeneratedOnAdd();
                        b.Property<int>("OrderId");
                        b.Property<int>("ProductId");
                        b.Property<int>("Quantity");
                        b.Property<decimal>("UnitPrice");
                        b.HasKey("OrderDetailId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.Product", b =>
                    {
                        b.Property<int>("CategoryId");
                        b.Property<DateTime>("Created");
                        b.Property<decimal>("Price");
                        b.Property<string>("ProductArtUrl");
                        b.Property<int>("ProductId")
                            .ValueGeneratedOnAdd();
                        b.Property<decimal>("SalePrice");
                        b.Property<string>("Title");
                        b.HasKey("ProductId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.Raincheck", b =>
                    {
                        b.Property<string>("Name");
                        b.Property<int>("ProductId");
                        b.Property<int>("Quantity");
                        b.Property<int>("RaincheckId")
                            .ValueGeneratedOnAdd();
                        b.Property<double>("SalePrice");
                        b.Property<int>("StoreId");
                        b.HasKey("RaincheckId");
                    });

                modelBuilder.Entity("PartsUnlimited.Models.Store", b =>
                    {
                        b.Property<string>("Name");
                        b.Property<int>("StoreId")
                            .ValueGeneratedOnAdd();
                        b.HasKey("StoreId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.ApplicationUser", "UserId");
                    });
                
                modelBuilder.Entity("PartsUnlimited.Models.CartItem", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.Product", "ProductId");
                    });
                
                modelBuilder.Entity("PartsUnlimited.Models.OrderDetail", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.Order", "OrderId");
                        b.ForeignKey("PartsUnlimited.Models.Product", "ProductId");
                    });
                
                modelBuilder.Entity("PartsUnlimited.Models.Product", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.Category", "CategoryId");
                    });
                
                modelBuilder.Entity("PartsUnlimited.Models.Raincheck", b =>
                    {
                        b.ForeignKey("PartsUnlimited.Models.Store", "StoreId");
                        b.ForeignKey("PartsUnlimited.Models.Product", "ProductId");
                    });
                
#pragma warning restore 612, 618
        }
    }
}