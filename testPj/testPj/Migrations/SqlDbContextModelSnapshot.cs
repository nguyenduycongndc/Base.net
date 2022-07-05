﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testPj.Data;

namespace testPj.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("testPj.Data.InputToolBuy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<int>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<string>("RequestBody")
                        .HasMaxLength(4000)
                        .HasColumnType("VARCHAR(4000)");

                    b.HasKey("Id");

                    b.ToTable("INPUT_TOOL_BUY");
                });

            modelBuilder.Entity("testPj.Data.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("testPj.Data.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("AddressWallet")
                        .HasColumnType("longtext")
                        .HasColumnName("address_wallet");

                    b.Property<double>("BNB")
                        .HasColumnType("double")
                        .HasColumnName("BNB");

                    b.Property<double>("Buy_TAU")
                        .HasColumnType("double")
                        .HasColumnName("Buy_TAU");

                    b.Property<string>("Class")
                        .HasColumnType("longtext")
                        .HasColumnName("class");

                    b.Property<DateTime?>("Date_Buy")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date_Buy");

                    b.Property<DateTime?>("Date_Sell")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date_Sell");

                    b.Property<int>("IdNFT")
                        .HasColumnType("int")
                        .HasColumnName("id_nft");

                    b.Property<int>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<int>("IsCheck")
                        .HasColumnType("int")
                        .HasColumnName("is_check");

                    b.Property<bool>("Is_Selling")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Is_Selling");

                    b.Property<double>("Sell_TAU")
                        .HasColumnType("double")
                        .HasColumnName("Sell_TAU");

                    b.Property<double>("TAU")
                        .HasColumnType("double")
                        .HasColumnName("TAU");

                    b.Property<double>("USD")
                        .HasColumnType("double")
                        .HasColumnName("USD");

                    b.Property<string>("rarity")
                        .HasColumnType("longtext")
                        .HasColumnName("rarity");

                    b.HasKey("Id");

                    b.ToTable("TRANSACTION_HISTORY");
                });

            modelBuilder.Entity("testPj.Data.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DateOfJoining")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_joining");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext")
                        .HasColumnName("full_name");

                    b.Property<int>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<int?>("IsDeleted")
                        .HasColumnType("int")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("modified_by");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("SaltKey")
                        .HasColumnType("longtext")
                        .HasColumnName("salt");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("testPj.Data.UsersRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("roles_id")
                        .HasColumnType("int");

                    b.Property<int?>("users_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("roles_id");

                    b.HasIndex("users_id");

                    b.ToTable("USERS_ROLES");
                });

            modelBuilder.Entity("testPj.Data.WalletManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("AddressWallet")
                        .HasColumnType("longtext")
                        .HasColumnName("address_wallet");

                    b.Property<string>("BNB")
                        .HasColumnType("longtext")
                        .HasColumnName("BNB");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int")
                        .HasColumnName("deleted_by");

                    b.Property<int>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<int>("IsCheck")
                        .HasColumnType("int")
                        .HasColumnName("is_check");

                    b.Property<int?>("IsDeleted")
                        .HasColumnType("int")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("modified_by");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("longtext")
                        .HasColumnName("private _key");

                    b.Property<string>("TAU")
                        .HasColumnType("longtext")
                        .HasColumnName("TAU");

                    b.Property<int?>("users_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("users_id");

                    b.ToTable("WALLET_MANAGEMENT");
                });

            modelBuilder.Entity("testPj.Data.UsersRoles", b =>
                {
                    b.HasOne("testPj.Data.Roles", "Roles")
                        .WithMany("UsersRoles")
                        .HasForeignKey("roles_id");

                    b.HasOne("testPj.Data.Users", "Users")
                        .WithMany("UsersRoles")
                        .HasForeignKey("users_id");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("testPj.Data.WalletManagement", b =>
                {
                    b.HasOne("testPj.Data.Users", "Users")
                        .WithMany("WalletManagements")
                        .HasForeignKey("users_id");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("testPj.Data.Roles", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("testPj.Data.Users", b =>
                {
                    b.Navigation("UsersRoles");

                    b.Navigation("WalletManagements");
                });
#pragma warning restore 612, 618
        }
    }
}
