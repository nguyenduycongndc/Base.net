﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testPj.Data;

namespace testPj.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20220614143655_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

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

            modelBuilder.Entity("testPj.Data.Roles", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("testPj.Data.Users", b =>
                {
                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
