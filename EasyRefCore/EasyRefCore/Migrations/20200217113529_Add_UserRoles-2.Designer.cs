﻿// <auto-generated />
using System;
using EasyRefCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyRefCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200217113529_Add_UserRoles-2")]
    partial class Add_UserRoles2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyRefCore.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Compound")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("CoachId");

                    b.HasIndex("RoleId");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("EasyRefCore.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwayTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameAgeId")
                        .HasColumnType("int");

                    b.Property<int?>("GameDivisionId")
                        .HasColumnType("int");

                    b.Property<int?>("GameFieldSizeId")
                        .HasColumnType("int");

                    b.Property<int>("GameGenderId")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RefereeId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondRefereeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ThirdRefereeId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("CoachId");

                    b.HasIndex("GameAgeId");

                    b.HasIndex("GameDivisionId");

                    b.HasIndex("GameFieldSizeId");

                    b.HasIndex("GameGenderId");

                    b.HasIndex("RefereeId");

                    b.HasIndex("SecondRefereeId");

                    b.HasIndex("ThirdRefereeId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("EasyRefCore.Models.GameAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameAge");
                });

            modelBuilder.Entity("EasyRefCore.Models.GameDivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Division")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameDivison");
                });

            modelBuilder.Entity("EasyRefCore.Models.GameFieldSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameFieldSize");
                });

            modelBuilder.Entity("EasyRefCore.Models.GameGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameGender");
                });

            modelBuilder.Entity("EasyRefCore.Models.Referee", b =>
                {
                    b.Property<int>("RefereeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Compound")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FieldSizeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RefereeId");

                    b.HasIndex("FieldSizeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Referee");
                });

            modelBuilder.Entity("EasyRefCore.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EasyRefCore.Models.Coach", b =>
                {
                    b.HasOne("EasyRefCore.Models.Role", "Role")
                        .WithMany("CoachUser")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyRefCore.Models.Game", b =>
                {
                    b.HasOne("EasyRefCore.Models.Coach", "Coach")
                        .WithMany("Games")
                        .HasForeignKey("CoachId");

                    b.HasOne("EasyRefCore.Models.GameAge", "GameAge")
                        .WithMany("Game")
                        .HasForeignKey("GameAgeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EasyRefCore.Models.GameDivision", "GameDivision")
                        .WithMany("Games")
                        .HasForeignKey("GameDivisionId");

                    b.HasOne("EasyRefCore.Models.GameFieldSize", "GameFieldSize")
                        .WithMany("Games")
                        .HasForeignKey("GameFieldSizeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EasyRefCore.Models.GameGender", "GameGender")
                        .WithMany("Games")
                        .HasForeignKey("GameGenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EasyRefCore.Models.Referee", "Referee")
                        .WithMany("GameReferee")
                        .HasForeignKey("RefereeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EasyRefCore.Models.Referee", "SecondReferee")
                        .WithMany("GameSecondReferee")
                        .HasForeignKey("SecondRefereeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EasyRefCore.Models.Referee", "ThirdReferee")
                        .WithMany("GameThirdReferee")
                        .HasForeignKey("ThirdRefereeId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("EasyRefCore.Models.Referee", b =>
                {
                    b.HasOne("EasyRefCore.Models.GameFieldSize", "FieldSize")
                        .WithMany()
                        .HasForeignKey("FieldSizeId");

                    b.HasOne("EasyRefCore.Models.Role", "Role")
                        .WithMany("RefereeUser")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
