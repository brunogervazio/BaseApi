﻿// <auto-generated />
using System;
using BaseApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaseApi.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseApi.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("UpdatedAt")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Uuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BaseApi.Domain.Entities.UserEntity", b =>
                {
                    b.OwnsOne("BaseApi.Domain.ValueObjcts.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserEntityUuid")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("UserEntityUuid");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityUuid");
                        });

                    b.OwnsOne("BaseApi.Domain.ValueObjcts.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserEntityUuid")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EncryptedValue")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Password");

                            b1.HasKey("UserEntityUuid");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityUuid");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
