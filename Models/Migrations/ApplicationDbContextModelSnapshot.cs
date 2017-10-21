﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Models;
using Models.Database.Tables;
using System;

namespace Models.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Database.Tables.UserEventNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("IdPlace");

                    b.Property<int>("IdUser");

                    b.Property<bool>("IsSended");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("UserEventNotifications");
                });

            modelBuilder.Entity("Models.Database.Tables.UserNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdUser");

                    b.Property<Guid>("IdUserEvent");

                    b.Property<int?>("IdUserFrom");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("IdUserEvent");

                    b.HasIndex("IdUserFrom");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Avatar");

                    b.Property<bool>("CanRecieveGroupMessages");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsFamiliarWithBot");

                    b.Property<DateTime>("LastEnter");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Gender");

                    b.Property<string>("IdPlace")
                        .IsRequired();

                    b.Property<int>("IdUser");

                    b.Property<int>("UserCount");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Models.UserEventOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdUser");

                    b.Property<Guid>("IdUserEvent");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("IdUserEvent");

                    b.ToTable("UserEventOffer");
                });

            modelBuilder.Entity("Models.Database.Tables.UserEventNotification", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Database.Tables.UserNotification", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.UserEvent", "UserEvent")
                        .WithMany()
                        .HasForeignKey("IdUserEvent")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.User", "UserFrom")
                        .WithMany()
                        .HasForeignKey("IdUserFrom");
                });

            modelBuilder.Entity("Models.UserEvent", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.UserEventOffer", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.UserEvent", "UserEvent")
                        .WithMany("Offers")
                        .HasForeignKey("IdUserEvent")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
